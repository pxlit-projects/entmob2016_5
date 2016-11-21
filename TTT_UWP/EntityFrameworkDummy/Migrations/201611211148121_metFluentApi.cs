namespace EntityFrameworkDummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class metFluentApi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Product", newName: "Products");
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            RenameTable(name: "dbo.Products", newName: "Product");
        }
    }
}
