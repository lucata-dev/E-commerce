namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Image_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Image_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.Image_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "CompanyName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "State_Id", "dbo.States");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductImages", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("dbo.ProductImages", new[] { "Image_Id" });
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "State_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AlterColumn("dbo.AspNetUsers", "CompanyName", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 100));
            DropTable("dbo.OrderProducts");
            DropTable("dbo.ProductImages");
            DropTable("dbo.States");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
        }
    }
}
