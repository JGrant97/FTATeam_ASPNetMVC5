namespace FTATeam_ASPNetMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagePathRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TeamImages", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeamImages", "Path", c => c.String(nullable: false));
        }
    }
}
