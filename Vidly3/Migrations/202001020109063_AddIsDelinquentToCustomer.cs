namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDelinquentToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDelinquent", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDelinquent");
        }
    }
}
