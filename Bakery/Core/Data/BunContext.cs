using Bakery.Core.Model.Bun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Data
{
    public class BunContext : DbContext
    {
        public DbSet<BunBase> Buns { get; set; }

        public BunContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BunDB;Trusted_Connection=True;");
        }
    }
}
