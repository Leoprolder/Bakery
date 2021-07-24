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
        public DbSet<Bun> Buns { get; set; }

        public BunContext()
        {
            Database.EnsureCreated();
        }

        public BunContext(DbContextOptions<BunContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bakery;Trusted_Connection=True;");
        }
    }
}
