using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigData.Shared.Models
{
    public class CoreUser
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Nation { get; set; }
        [Required]
        public DateTime InsertDate { get; set; }
    }
}
