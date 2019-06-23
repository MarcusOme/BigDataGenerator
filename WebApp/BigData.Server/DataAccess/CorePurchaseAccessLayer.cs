using BigData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server.DataAccess
{
    public class CorePurchaseAccessLayer
    {
        CorePurchaseContext db = new CorePurchaseContext();
        CoreUserContext db_user = new CoreUserContext();
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
            //load 10000 users from the database
            IEnumerable<CoreUser> user_list = db_user.tblCoreUser.ToList().OrderBy(x => x.ID).Take(10000);
        }
    }
}
