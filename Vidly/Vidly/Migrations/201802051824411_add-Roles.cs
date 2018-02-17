namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'5bebddfd-7537-4dd6-89a0-a430d9ac1832', N'admin', N'AI/YxzsFkmmTAnLd6d39wfhMFCHeQZdcGB4beIU5066BsgBtot5uaWZimS80UHYU9Q==', N'f5812e52-368c-4e7a-a5f0-d33ac85feeff', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'aee619e9-5958-4bba-870f-8f25a0ba8b2b', N'guest', N'AEIMUWGvC0nOtWb1YgC5Gvv1H+IpmKpkgrf/Kk79wRYay7XFtdsm91iiuMrY7rtPRA==', N'1d343036-09ac-4279-a888-7a9cdd3ef1b9', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'ba8dfafa-2b33-40a4-8700-7e11ab07b9a7', N'adminnew', N'AF+GSCdRxk8yXUjthsY4x06aEDRfKpzEEYyFDeAgUYMN1R+V8dpeeZlQkp5lchGHDg==', N'956b774a-02ca-410d-bb40-76781759237f', N'ApplicationUser')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2a0948b2-6fd2-4550-b3fb-f5faec770bf3', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ba8dfafa-2b33-40a4-8700-7e11ab07b9a7', N'2a0948b2-6fd2-4550-b3fb-f5faec770bf3')

");
        }

        public override void Down()
        {
        }
    }
}
