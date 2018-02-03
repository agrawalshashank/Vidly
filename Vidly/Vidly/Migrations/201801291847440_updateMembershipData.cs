namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updateMembershipData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (MembershipName,DurationInMonths,MemberShipFee,Discount) VALUES ('PAYASUGO',0,0,0)");
            Sql("Insert into MembershipTypes (MembershipName,DurationInMonths,MemberShipFee,Discount) VALUES ('Monthly',12,300,10)");
            Sql("Insert into MembershipTypes (MembershipName,DurationInMonths,MemberShipFee,Discount) VALUES ('Quaterly',4,500,20)");
            Sql("Insert into MembershipTypes (MembershipName,DurationInMonths,MemberShipFee,Discount) VALUES ('Yearly',1,1000,30)");

        }

        public override void Down()
        {
        }
    }
}
