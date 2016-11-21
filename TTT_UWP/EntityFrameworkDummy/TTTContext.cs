using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Domainclasses;

namespace EntityFrameworkDummy
{
    class TTTContext : DbContext
    {

        public TTTContext() : base("TTTContext")
        {

        }

        public DbSet<Observation> Observations { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var products = modelBuilder.Entity<Product>();
            products.ToTable("Products");
            products.Property(g => g.ProductName).IsRequired();
            products.Property(g => g.ProductName).HasMaxLength(50);
            products.HasKey(g => g.ProductID);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
