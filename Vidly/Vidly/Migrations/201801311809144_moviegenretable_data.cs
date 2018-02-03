namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviegenretable_data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        NumberInStocks = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);

            Sql("Insert into Genres (Name) VALUES ('Action')");
            Sql("Insert into Genres (Name) VALUES ('Drama')");
            Sql("Insert into Genres (Name) VALUES ('Horror')");
            Sql("Insert into Genres (Name) VALUES ('Commedy')");
            


            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
