namespace FTATeam_ASPNetMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [Name]) VALUES (N'64b84eed-69d9-47f3-9567-3e5bac7de122', N'jackgrant97@live.co.uk', N'jackgrant97@live.co.uk', 0, N'AHcuZswUNIpRn8dMopvuuiKY9N/eJj8/mKI9vFcUPRK2UA7p2Es2uRfnIgnl53aVWA==', N'5afd13dd-adb9-4702-8fd3-595f85557b16', NULL, 0, 0, NULL, 1, 0, N'Nomad_UK')" +
                "INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'98d548ba-f364-4f23-88d5-92c442c2854d', N'CanManageImages')" +
                "INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'64b84eed-69d9-47f3-9567-3e5bac7de122', N'98d548ba-f364-4f23-88d5-92c442c2854d')");
        }
        
        public override void Down()
        {
        }
    }
}
