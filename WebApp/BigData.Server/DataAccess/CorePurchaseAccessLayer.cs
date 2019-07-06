using BigData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace BigData.Server.DataAccess
{
    public class CorePurchaseAccessLayer
    {
        CorePurchaseContext db = new CorePurchaseContext();
        CoreUserContext db_user = new CoreUserContext();
        CoreProductContext db_prod = new CoreProductContext();
        /// <summary>
        /// Function to get all the purchase present inside the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CorePurchase> getAllUer()
        {
            return db.tblCorePurchase.ToList<CorePurchase>();
        }

        /// <summary>
        /// The function creates purchase for each client inside the product list, for optimization reasons
        /// a bins of 10000 users and 10000 elements is choosen each time to avoid problems with the 
        /// number of records inside the tables
        /// </summary>
        public void InsertPurchase()
        {
            int prodNum = 262111;
            int usrNum = 20000;

            //create random purchase for each user
            Random usrRand = new Random();
            Random prodRand = new Random();
            Random dayRand = new Random();
            Random qtaRand = new Random();

            //set a number of purchase
            int purchaseNumber = 30000;
            List<CorePurchase> purchase = new List<CorePurchase>();
            for(int i = 0; i < purchaseNumber; i++)
            {
                int ui = usrRand.Next(usrNum);
                int pi = prodRand.Next(prodNum);
                int qta = qtaRand.Next(0, 100);
                int day = dayRand.Next(0, 730);

                CoreUser tmp_user = db_user.tblCoreUser.Find(ui);
                CoreProduct tmp_prod = db_prod.tblCoreProduct.Find(pi);

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
                if(i % 10000 == 0)
                {
                    db.AddRange(purchase);
                    db.SaveChanges();
                    purchase.Clear();
                    db = new CorePurchaseContext();
                }
            }

            if(purchase.Count > 0)
            {
                db = new CorePurchaseContext();
                db.AddRange(purchase);
                db.SaveChanges();
                purchase.Clear();
            }

            /*At this point use the machine learning toolbox to generate probable element to sell*/
        }

    }
}
