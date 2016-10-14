namespace EntityFrameworkDummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Observation",
                c => new
                    {
                        ObservationID = c.Int(nullable: false, identity: true),
                        RegionID = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Temperature = c.Double(nullable: false),
                        Humidity = c.Double(nullable: false),
                        AirPressure = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ObservationID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        MinimumTemperature = c.Double(nullable: false),
                        MaximumTemperature = c.Double(nullable: false),
                        MinimumHumidity = c.Double(nullable: false),
                        MaximumHumidity = c.Double(nullable: false),
                        MinimumAirPressure = c.Double(nullable: false),
                        MaximumAirPressure = c.Double(nullable: false),
                        RackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Rack",
                c => new
                    {
                        RackID = c.Int(nullable: false, identity: true),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RackID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                        WarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegionID)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(),
                    })
                .PrimaryKey(t => t.WarehouseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Region", "WarehouseID", "dbo.Warehouse");
            DropIndex("dbo.Region", new[] { "WarehouseID" });
            DropTable("dbo.Warehouse");
            DropTable("dbo.Region");
            DropTable("dbo.Rack");
            DropTable("dbo.Product");
            DropTable("dbo.Observation");
        }
    }
}
