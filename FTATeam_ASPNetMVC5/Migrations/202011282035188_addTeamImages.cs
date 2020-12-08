namespace FTATeam_ASPNetMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTeamImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamImages");
        }
    }
}
