namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershiprecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName= 'PayAsYouGo' where Id=1 ");
        }
        
        public override void Down()
        {
        }
    }
}
