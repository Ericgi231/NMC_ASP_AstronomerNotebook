namespace AstronomerNotebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Astronomers",
                c => new
                    {
                        AstronomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AstronomerId);
            
            CreateTable(
                "dbo.Clusters",
                c => new
                    {
                        ClusterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Constellation = c.Int(nullable: false),
                        ClusterType = c.Int(nullable: false),
                        ApparentMagnitude = c.Double(),
                        RightAscension = c.Double(),
                        Declination = c.Double(),
                        AstronomerId = c.Int(),
                        GalaxyId = c.Int(),
                    })
                .PrimaryKey(t => t.ClusterId)
                .ForeignKey("dbo.Astronomers", t => t.AstronomerId)
                .ForeignKey("dbo.Galaxies", t => t.GalaxyId)
                .Index(t => t.AstronomerId)
                .Index(t => t.GalaxyId);
            
            CreateTable(
                "dbo.Galaxies",
                c => new
                    {
                        GalaxyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Constellation = c.Int(nullable: false),
                        GalaxyType = c.Int(nullable: false),
                        ApparentMagnitude = c.Double(),
                        RightAscension = c.Double(),
                        Declination = c.Double(),
                        AstronomerId = c.Int(),
                    })
                .PrimaryKey(t => t.GalaxyId)
                .ForeignKey("dbo.Astronomers", t => t.AstronomerId)
                .Index(t => t.AstronomerId);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        StarId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Constellation = c.Int(nullable: false),
                        ApparentMagnitude = c.Double(),
                        RightAscension = c.Double(),
                        Declination = c.Double(),
                        AstronomerId = c.Int(),
                        ClusterId = c.Int(),
                    })
                .PrimaryKey(t => t.StarId)
                .ForeignKey("dbo.Astronomers", t => t.AstronomerId)
                .ForeignKey("dbo.Clusters", t => t.ClusterId)
                .Index(t => t.AstronomerId)
                .Index(t => t.ClusterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stars", "ClusterId", "dbo.Clusters");
            DropForeignKey("dbo.Stars", "AstronomerId", "dbo.Astronomers");
            DropForeignKey("dbo.Clusters", "GalaxyId", "dbo.Galaxies");
            DropForeignKey("dbo.Galaxies", "AstronomerId", "dbo.Astronomers");
            DropForeignKey("dbo.Clusters", "AstronomerId", "dbo.Astronomers");
            DropIndex("dbo.Stars", new[] { "ClusterId" });
            DropIndex("dbo.Stars", new[] { "AstronomerId" });
            DropIndex("dbo.Galaxies", new[] { "AstronomerId" });
            DropIndex("dbo.Clusters", new[] { "GalaxyId" });
            DropIndex("dbo.Clusters", new[] { "AstronomerId" });
            DropTable("dbo.Stars");
            DropTable("dbo.Galaxies");
            DropTable("dbo.Clusters");
            DropTable("dbo.Astronomers");
        }
    }
}
