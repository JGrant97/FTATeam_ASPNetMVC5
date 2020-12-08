namespace FTATeam_ASPNetMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileToImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamImages", "File", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamImages", "File");
        }
    }
}
