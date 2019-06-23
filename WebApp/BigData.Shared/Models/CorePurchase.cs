using System;
using System.Collections.Generic;
using System.Text;

namespace BigData.Shared.Models
{
    public class CorePurchase
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
