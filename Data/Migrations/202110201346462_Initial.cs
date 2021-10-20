namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        EarthMassAU = c.Double(name: "Earth Mass (AU)", nullable: false),
                        DistanceToTheSunAU = c.Double(name: "Distance To The Sun (AU)", nullable: false),
                        CreatedAt = c.DateTime(name: "Created At", nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(name: "Updated At", nullable: false, precision: 7, storeType: "datetime2"),
                        ComponentId = c.Int(name: "Component Id", nullable: false),
                        RegionId = c.Int(name: "Region Id", nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.ComponentId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Type = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(name: "Created At", nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(name: "Updated At", nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DistanceToTheSunAU = c.Double(name: "Distance To The Sun (AU)", nullable: false),
                        CreatedAt = c.DateTime(name: "Created At", nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(name: "Updated At", nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bodies", "Region Id", "dbo.Regions");
            DropForeignKey("dbo.Bodies", "Component Id", "dbo.Components");
            DropIndex("dbo.Bodies", new[] { "Region Id" });
            DropIndex("dbo.Bodies", new[] { "Component Id" });
            DropTable("dbo.Regions");
            DropTable("dbo.Components");
            DropTable("dbo.Bodies");
        }
    }
}
