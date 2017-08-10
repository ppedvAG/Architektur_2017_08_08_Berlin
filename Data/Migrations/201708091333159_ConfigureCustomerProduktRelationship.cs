namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureCustomerProduktRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KundenProdukte",
                c => new
                    {
                        KundenId = c.Int(nullable: false),
                        ProduktId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KundenId, t.ProduktId })
                .ForeignKey("dbo.Kunden", t => t.KundenId, cascadeDelete: true)
                .ForeignKey("dbo.Produkte", t => t.ProduktId, cascadeDelete: true)
                .Index(t => t.KundenId)
                .Index(t => t.ProduktId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KundenProdukte", "ProduktId", "dbo.Produkte");
            DropForeignKey("dbo.KundenProdukte", "KundenId", "dbo.Kunden");
            DropIndex("dbo.KundenProdukte", new[] { "ProduktId" });
            DropIndex("dbo.KundenProdukte", new[] { "KundenId" });
            DropTable("dbo.KundenProdukte");
        }
    }
}
