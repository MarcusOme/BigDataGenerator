using BigData.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server.DataAccess
{
    public class CoreProductAccessLayer
    {
        //create the connection object
        CoreProductContext db = new CoreProductContext();

        /// <summary>
        /// Function to get all the users present inside the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CoreProduct> getAllUer()
        {
            return db.tblCoreProduct.ToList<CoreProduct>();
        }

        public void InsertProduct()
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

                    db.tblCoreProduct.AddRange(products);
                    db.SaveChanges();
                    //empty the list
                    products.Clear();
                    db = new CoreProductContext();
                }

            }
            //check remaining
            if (products.Count() > 0)
            {
                db = new CoreProductContext();
                db.tblCoreProduct.AddRange(products);
                db.SaveChanges();
            }
            db.Dispose();
            products.Clear();
        }
    }
}
