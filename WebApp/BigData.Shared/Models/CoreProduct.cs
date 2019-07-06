using System;
using System.Collections.Generic;
using System.Text;

namespace BigData.Shared.Models
{
    public class CoreProduct
    {
        public int ID { get; set; }
        public int ProdID { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertionDate { get; set; }
    }
}
