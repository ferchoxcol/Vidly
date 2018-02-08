namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserManagerRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cf938189-0dfd-4b06-aec8-021e4cc1286b', N'CanManageCustomer')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'574f4b64-558d-40b7-887f-f97bc6c8b406', N'cf938189-0dfd-4b06-aec8-021e4cc1286b')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
