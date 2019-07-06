using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigData.Shared.Models
{
    public class CoreUser
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nation { get; set; }

        public DateTime InsertDate { get; set; }
    }
}
