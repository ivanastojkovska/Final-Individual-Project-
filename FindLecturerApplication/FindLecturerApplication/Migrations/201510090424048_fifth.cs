namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropForeignKey("dbo.Fields", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropIndex("dbo.Courses", new[] { "UserProfile_ProfileID" });
            DropIndex("dbo.Fields", new[] { "UserProfile_ProfileID" });
            AddColumn("dbo.UserProfiles", "CourseID", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "Field_FieldID", c => c.Int());
            AlterColumn("dbo.UserProfiles", "FormalEducation", c => c.String());
            CreateIndex("dbo.UserProfiles", "CourseID");
            CreateIndex("dbo.UserProfiles", "Field_FieldID");
            AddForeignKey("dbo.UserProfiles", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.UserProfiles", "Field_FieldID", "dbo.Fields", "FieldID");
            DropColumn("dbo.Courses", "UserProfile_ProfileID");
            DropColumn("dbo.Fields", "UserProfile_ProfileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fields", "UserProfile_ProfileID", c => c.Int());
            AddColumn("dbo.Courses", "UserProfile_ProfileID", c => c.Int());
            DropForeignKey("dbo.UserProfiles", "Field_FieldID", "dbo.Fields");
            DropForeignKey("dbo.UserProfiles", "CourseID", "dbo.Courses");
            DropIndex("dbo.UserProfiles", new[] { "Field_FieldID" });
            DropIndex("dbo.UserProfiles", new[] { "CourseID" });
            AlterColumn("dbo.UserProfiles", "FormalEducation", c => c.String(nullable: false));
            DropColumn("dbo.UserProfiles", "Field_FieldID");
            DropColumn("dbo.UserProfiles", "CourseID");
            CreateIndex("dbo.Fields", "UserProfile_ProfileID");
            CreateIndex("dbo.Courses", "UserProfile_ProfileID");
            AddForeignKey("dbo.Fields", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
            AddForeignKey("dbo.Courses", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
        }
    }
}
