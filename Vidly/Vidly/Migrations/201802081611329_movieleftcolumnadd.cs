namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieleftcolumnadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MoviesLeft", c => c.Int(nullable: false));
            Sql("Update Movies Set MoviesLeft=NumberInStocks");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MoviesLeft");
        }
    }
}
