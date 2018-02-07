namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'064afb0f-fa18-4c47-988e-0be3f799c16c', N'guest@vidly.com', 0, N'AP05mHTD77GXDcenLKV4SsvNbEfsw0GFWH+OrsY21YPK/iNdr5NKWGHVlqG6Dg1EUw==', N'8c4530ac-e086-437b-b4a5-91a4ce0d804a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com') 
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'31b3bf18-fd19-4f04-b30d-e61c3d098063', N'ab@gmail.com', 0, N'AJ6+J0Z38Gia4tJHaU5gRQNK78prYPOKmboPDdw6t5xJQDz+GBppfFiINa9UAITBFg==', N'a93ded37-ef97-4f1e-8168-bd82debd20e5', NULL, 0, 0, NULL, 1, 0, N'ab@gmail.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'574f4b64-558d-40b7-887f-f97bc6c8b406', N'Admin@vidly.com', 0, N'AA7y+04q2MwA+K9dgmkzfdSBLiejaxXhvgGhr2eoCxxKoQln6wUIUi5jWjwcf9sHmg==', N'3e1fe4a4-a0d8-40ba-b90c-b8353424cb33', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3e30994f-b0f5-4edf-8141-87b38f7a0e1c', N'CanManageMovie')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'574f4b64-558d-40b7-887f-f97bc6c8b406',N'3e30994f-b0f5-4edf-8141-87b38f7a0e1c')


");
        }
        
        public override void Down()
        {
        }
    }
}
