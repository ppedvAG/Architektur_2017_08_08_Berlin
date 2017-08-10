namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Kunden");
            AlterColumn("dbo.Kunden", "Firstname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Kunden", "Lastname", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kunden", "Lastname", c => c.String());
            AlterColumn("dbo.Kunden", "Firstname", c => c.String());
            RenameTable(name: "dbo.Kunden", newName: "Customers");
        }
    }
}
