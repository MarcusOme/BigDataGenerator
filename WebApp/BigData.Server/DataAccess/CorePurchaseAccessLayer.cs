using BigData.Shared.Models;
using Dapper;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace BigData.Server.DataAccess
{
    public class CorePurchaseAccessLayer
    {
        CorePurchaseContext db = new CorePurchaseContext();
        CoreUserContext db_user = new CoreUserContext();
        CoreProductContext db_prod = new CoreProductContext();

        string conn_str = @"Server=.\SQLExpress;Database=BigData;Trusted_Connection=True;MultipleActiveResultSets=true";

        /// <summary>
        /// Function to get all the purchase present inside the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CorePurchase> getAllPurchase()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                var res = connection.Query<CorePurchase>("SELECT * FROM CorePurchase").ToList();
                return res;
            }
        }

        /// <summary>
        /// The function creates purchase for each client inside the product list, for optimization reasons
        /// a bins of 10000 users and 10000 elements is choosen each time to avoid problems with the 
        /// number of records inside the tables
        /// </summary>
        public void InsertPurchase()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                try
                {
                    //int prodNum = 262110;
                    //int usrNum = 20000;
                    int prodNum = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM CoreProduct");
                    int usrNum = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM CoreUser");

                    //create random purchase for each user
                    Random usrRand = new Random();
                    Random prodRand = new Random();
                    Random dayRand = new Random();
                    Random qtaRand = new Random();

                    //set a number of purchase -> for base purchasing
                    int purchaseNumber = 30000;
                    List<CorePurchase> purchase = new List<CorePurchase>();
                    for (int i = 0; i < purchaseNumber; i++)
                    {
                        int ui = usrRand.Next(0, usrNum);
                        int pi = prodRand.Next(1, prodNum);
                        int qta = qtaRand.Next(0, 100);
                        int day = dayRand.Next(0, 730);

                        //CoreUser tmp_user = db_user.tblCoreUser.Find(ui);
                        //CoreProduct tmp_prod = db_prod.tblCoreProduct.Find(pi);

                        CoreUser tmp_user = connection.QueryFirst<CoreUser>("SELECT * FROM CoreUser WHERE ID=@UserID", new { UserID = ui});
                        CoreProduct tmp_prod = connection.QueryFirst<CoreProduct>("SELECT * FROM CoreProduct WHERE ProdID=@ProdID", new { ProdID = pi});

                        //create the association
                        CorePurchase cp = new CorePurchase()
                        {
                            ProductID = tmp_prod.ProdID,
                            UserID = tmp_user.ID,
                            Quantity = qta,
                            PurchaseDate = DateTime.Now.AddDays(-day)
                        };

                        purchase.Add(cp);

                        //wait for 1000 and insert
                        if (i % 10000 == 0)
                        {
                            //db.AddRange(purchase);
                            //db.SaveChanges();
                            connection.BulkInsert(purchase);
                            purchase.Clear();
                            //db = new CorePurchaseContext();
                        }
                    }

                    if (purchase.Count > 0)
                    {
                        //db = new CorePurchaseContext();
                        //db.AddRange(purchase);
                        //db.SaveChanges();
                        connection.BulkInsert(purchase);
                        purchase.Clear();
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Product entry for prediction
        /// </summary>
        public class ProductEntry
        {
            [KeyType(count: 262111)]
            public uint ProductID { get; set; }

            [KeyType(count: 262111)]
            public uint CoPurchaseProductID { get; set; }
        }

        /// <summary>
        /// result class for the prediction
        /// </summary>
        public class Copurchase_prediction
        {
            public float Score { get; set; }
        }

        /// <summary>
        /// Create and train the model on the basis of the Amazon file
        /// </summary>
        /// <returns>
        /// PredictionEngine<a,b>, represent the engine that gives 2 id return a probability score of being suggested
        /// </returns>
        public PredictionEngine<ProductEntry, Copurchase_prediction> TrainModelAction()
        {
            try
            {
                //create the ML context
                MLContext mlContext = new MLContext();

                //read data from Amazon file
                string train_location = @"Content\Amazon0302.txt";
                var traindata = mlContext.Data.LoadFromTextFile(path: train_location,
                                                          columns: new[]
                                                                    {
                                                                    new TextLoader.Column("Label", DataKind.Single, 0),
                                                                    new TextLoader.Column(name:nameof(ProductEntry.ProductID), dataKind:DataKind.UInt32,                source: new [] { new TextLoader.Range(0) }, keyCount: new KeyCount(262111)),
                                                                    new TextLoader.Column(name:nameof(ProductEntry.CoPurchaseProductID),                                dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(1) }, keyCount: new KeyCount(262111))
                                                                    },
                                                          hasHeader: true,
                                                          separatorChar: '\t');

                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                // For better results use the following parameters
                options.C = 0.00001;

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                //now is possible to train the model
                ITransformer model = est.Fit(traindata);

                //creating the preduction engine that is returned
                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                return predictionengine;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Use prediction engine to create a series of purchase that are correlated by suggestions, not use all the users, but only a portion of them
        /// 
        /// </summary>
        public void PurchaseModelInsertion()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                try
                {
                    var predictionengine = TrainModelAction();
                    //foreach purchase already present select productID and check with all other ID using the prediction engine
                    var purchaseList = connection.Query<CorePurchase>("SELECT * FROM CorePurchase").ToList();
                    

                    //declare the adjunctive purchase list
                    List<CorePurchase> purchase = new List<CorePurchase>();
                    Random dayRand = new Random();
                    Random qtaRand = new Random();
                    foreach (var elem in purchaseList)
                    {
                        //modify the span to be more accurate
                        var productList = connection.Query<CoreProduct>("SELECT * FROM CoreProduct WHERE ProdID<@LastID AND ProdID>@FirstID", new { LastID = elem.ProductID + 100, FirstID = elem.ProductID-100}).ToList();
                        foreach (var prod in productList)
                        {
                            var prediction = predictionengine.Predict(
                                new ProductEntry()
                                {
                                    ProductID = Convert.ToUInt32(elem.ProductID),
                                    CoPurchaseProductID = Convert.ToUInt32(prod.ProdID)
                                }
                                );

                            //modify the percentage to be more or less precise while inserting
                            if (prediction.Score > 0.2)
                            {
                                int qta = qtaRand.Next(0, 100);
                                int day = dayRand.Next(0, 730);
                                //create new purchase
                                CorePurchase tmp = new CorePurchase()
                                {
                                    ProductID = elem.ProductID,
                                    UserID = elem.UserID,
                                    PurchaseDate = DateTime.Now.AddDays(-day),
                                    Quantity = qta
                                };
                                //insert inside the database the purchase
                                purchase.Add(tmp);
                            }
                        }
                    }

                    connection.BulkInsert(purchase);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
                
        }

    }
}
