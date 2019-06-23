using BigData.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server
{
    public class BigDataContext : DbContext
    {
        public BigDataContext(DbContextOptions<BigDataContext> options) : base(options)
        {
        }

        public DbSet<CoreUser> Users { get; set; }
    }
}
