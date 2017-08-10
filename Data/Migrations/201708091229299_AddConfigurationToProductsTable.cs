namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigurationToProductsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Produkte");
            AlterColumn("dbo.Produkte", "Number", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
            AlterColumn("dbo.Produkte", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produkte", "Name", c => c.String());
            AlterColumn("dbo.Produkte", "Number", c => c.String());
            RenameTable(name: "dbo.Produkte", newName: "Products");
        }
    }
}
