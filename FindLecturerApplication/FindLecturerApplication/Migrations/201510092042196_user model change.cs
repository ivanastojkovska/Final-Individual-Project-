namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermodelchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "User_ID", "dbo.Users");
            DropIndex("dbo.UserProfiles", new[] { "User_ID" });
            AddColumn("dbo.Users", "UserProfile_ProfileID", c => c.Int());
            CreateIndex("dbo.Users", "UserProfile_ProfileID");
            AddForeignKey("dbo.Users", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
            DropColumn("dbo.UserProfiles", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "User_ID", c => c.Int());
            DropForeignKey("dbo.Users", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "UserProfile_ProfileID" });
            DropColumn("dbo.Users", "UserProfile_ProfileID");
            CreateIndex("dbo.UserProfiles", "User_ID");
            AddForeignKey("dbo.UserProfiles", "User_ID", "dbo.Users", "ID");
        }
    }
}
