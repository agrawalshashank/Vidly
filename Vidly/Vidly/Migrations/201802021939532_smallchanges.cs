namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallchanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsNewsLetterSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsNewsLetterSubscribed", c => c.String());
        }
    }
}
