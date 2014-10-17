namespace Browar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Browarnias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Piwoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Power = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Genre = c.String(),
                        BrowarniaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Browarnias", t => t.BrowarniaId, cascadeDelete: true)
                .Index(t => t.BrowarniaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Piwoes", "BrowarniaId", "dbo.Browarnias");
            DropIndex("dbo.Piwoes", new[] { "BrowarniaId" });
            DropTable("dbo.Piwoes");
            DropTable("dbo.Browarnias");
        }
    }
}
