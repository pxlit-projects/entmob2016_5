namespace EntityFrameworkDummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nieuwe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sensor",
                c => new
                    {
                        SensorID = c.Int(nullable: false, identity: true),
                        Mac = c.String(),
                        Name = c.String(),
                        Region_RegionID = c.Int(),
                    })
                .PrimaryKey(t => t.SensorID)
                .ForeignKey("dbo.Region", t => t.Region_RegionID)
                .Index(t => t.Region_RegionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sensor", "Region_RegionID", "dbo.Region");
            DropIndex("dbo.Sensor", new[] { "Region_RegionID" });
            DropTable("dbo.Sensor");
        }
    }
}
