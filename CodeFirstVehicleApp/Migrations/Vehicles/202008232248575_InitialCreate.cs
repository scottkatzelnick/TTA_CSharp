namespace CodeFirstVehicleApp.Migrations.Vehicles
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Year = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Brand = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CarModelId)
                .ForeignKey("dbo.Makes", t => t.Brand)
                .Index(t => t.Brand);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Brand = c.String(nullable: false, maxLength: 30),
                        Address = c.String(maxLength: 100),
                        Circa = c.DateTime(nullable: false),
                        CEO = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Brand);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarModels", "Brand", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "Brand" });
            DropTable("dbo.Makes");
            DropTable("dbo.CarModels");
        }
    }
}
