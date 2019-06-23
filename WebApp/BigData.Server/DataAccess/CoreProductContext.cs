using BigData.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server.DataAccess
{
    public class CoreProductContext : DbContext
    {
        public virtual DbSet<CoreProduct> tblCoreProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=BigData;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
