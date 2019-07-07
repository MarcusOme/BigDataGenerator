using BigData.Shared.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace BigData.Server.DataAccess
{
    public class CoreProductAccessLayer : DataAccessgeneral
    {
        //create the connection object
        CoreProductContext db = new CoreProductContext();
        /// <summary>
        /// Function to get all the users present inside the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CoreProduct> getAllProduct()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                var res = connection.Query<CoreProduct>("SELECT * FROM tblCoreProduct").ToList();
                return res;
            }
                
        }

        public void InsertProduct()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                try
                {
                    //set the number of elements present inside Amazon0302.txt file
                    int number = 262111;

                    //foreach of those entries create a product and insert inside the dataset
                    List<CoreProduct> products = new List<CoreProduct>();
                    Random rand = new Random();
                    Random price = new Random();
                    for (int i = 0; i < number; i++)
                    {
                        int tmp_date = rand.Next(0, 730);   //two year span
                        decimal tmp_price = price.Next(10, 1000);
                        CoreProduct tmp = new CoreProduct()
                        {
                            ProdID = i,
                            Price = tmp_price,
                            InsertionDate = DateTime.Now.AddDays(-tmp_date)
                        };

                        products.Add(tmp);
                        if (i % 10000 == 0)
                        {

                            //db.tblCoreProduct.AddRange(products);
                            //db.SaveChanges();
                            connection.BulkInsert(products);
                            //empty the list
                            products.Clear();
                            //db = new CoreProductContext();

                        }

                    }
                    //check remaining
                    if (products.Count() > 0)
                    {
                        //db = new CoreProductContext();
                        //db.tblCoreProduct.AddRange(products);
                        //db.SaveChanges();
                        connection.BulkInsert(products);
                        products.Clear();
                    }
                    
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
