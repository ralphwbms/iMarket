namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Users] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a34292a-bf5f-4baf-b6d6-d46b7e7078ca', N'admin@imarket.com.br', 0, N'ACNdY6eqGsB951NKwJ3u8O3unqmtteUA6LDewmzdcNG95H9waDDBZKPg9w4pc4/8wQ==', N'275ddfcf-b5aa-4041-ab33-a7fcdea02153', NULL, 0, 0, NULL, 1, 0, N'admin@imarket.com.br')");
            Sql("INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4a34292a-bf5f-4baf-b6d6-d46b7e7078ca', '1')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM UserRoles WHERE UserId = N'4a34292a-bf5f-4baf-b6d6-d46b7e7078ca' AND RoleId = '1'");
            Sql("DELETE FROM Users WHERE Id = N'4a34292a-bf5f-4baf-b6d6-d46b7e7078ca'");
        }
    }
}
