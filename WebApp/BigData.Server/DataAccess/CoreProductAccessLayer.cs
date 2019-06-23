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
            //load the book list
            string[] allTitles = File.ReadAllText(@"Content\books_list.txt").Split(
                new[] {'\n'},
                StringSplitOptions.RemoveEmptyEntries
                );

            //check the booklist to delete unecessary elements
            List<string> titles = new List<string>();
            foreach(var s in allTitles)
            {
                if (s.Contains('['))
                {
                    //need to delete, do nothing

                }
                else if (string.IsNullOrWhiteSpace(s))
                {

                }
                else
                {
                    titles.Add(s);
                }
            }

            //use title to insert them inside the database
            int counter = 0;
            Random r1 = new Random();
            Random r2 = new Random();
            List<CoreProduct> products = new List<CoreProduct>();
            foreach (var t in titles)
            {
                int tmp1 = r1.Next(0, 730);
                int tmp2 = r2.Next(0, 100);
                var product = new CoreProduct()
                {
                    Name = t,
                    InsertDate = DateTime.Now.AddDays(-tmp1),
                    Price = tmp2
                };
                products.Add(product);
                

                counter++;

                if (counter % 10000 == 0)
                {
                    //save inside database
                    db.tblCoreProduct.AddRange(products);
                    db.SaveChanges();
                    db = new CoreProductContext();
                    products.Clear();
                }
            }
            if(products.Count > 0)
            {
                db.tblCoreProduct.AddRange(products);
                db.SaveChanges();
                db = new CoreProductContext();
                products.Clear();
            }

            
        }
    }
}
