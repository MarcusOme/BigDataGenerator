using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigData.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace BigData.Server.DataAccess
{
    public class CoreUserContext : DbContext
    {
        public virtual DbSet<CoreUser> tblCoreUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=BigData;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
