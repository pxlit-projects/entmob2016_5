namespace EntityFrameworkDummy.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TTT_UWP.Domainclasses;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkDummy.TTTContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkDummy.TTTContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Racks.AddOrUpdate(
                p => p.RackID,
                new Rack { RegionID = 1, Products = null },
                new Rack { RegionID = 2, Products = null },
                new Rack { RegionID = 3, Products = null },
                new Rack { RegionID = 4, Products = null },
                new Rack { RegionID = 3, Products = null },
                new Rack { RegionID = 3, Products = null },
                new Rack { RegionID = 3, Products = null }
            );
            context.SaveChanges();
        }
    }
}
