namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            //use @ verbatim string to write on multiple lines
            //will have made these users and roles before hand
            //copy these users and roles from View Data in SQL Server explorer and paste the scripts here
            //delete the users in the db so there are no duplicates then run this script
            //now when deploying to the production db you will initially get these users in their correct roles
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'e0e6fc91-0ba8-4728-821a-93dbaabedd17', N'user@vidly.com', 0, N'ABhsCVsj4aRAqe3LQKo5VxSfi7t0nJj97tsXVaFFLn6bJRSUXevhoP6xJM+DAnLx0A==', N'ba564da6-c247-4387-8819-0e03d49ad20b', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com', N'12345')

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'edc5528a-5a9a-421c-aad9-cebb80b6a67d', N'admin@vidly.com', 0, N'AFzjzUqy8LOq2iWpbm2mqh/C9hjJ69g+1ud0Tcm3Gbkg9iptlMYiSI4k4Rr7Wn5wyw==', N'3776df5c-5437-451d-af64-9f39423d8098', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f90ee5e3-441d-4ae5-986c-1bd17467b67c', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'edc5528a-5a9a-421c-aad9-cebb80b6a67d', N'f90ee5e3-441d-4ae5-986c-1bd17467b67c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
