namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        FormalEducation = c.String(),
                        ProfesionalExperience = c.String(nullable: false),
                        Skills = c.String(),
                        UserImage = c.String(),
                        Course_CourseID = c.Int(),
                        Field_FieldID = c.Int(),
                        Schedule_id = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .ForeignKey("dbo.Fields", t => t.Field_FieldID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_id)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Field_FieldID)
                .Index(t => t.Schedule_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Schedule_id", "dbo.Schedules");
            DropForeignKey("dbo.UserProfiles", "Field_FieldID", "dbo.Fields");
            DropForeignKey("dbo.UserProfiles", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.UserProfiles", new[] { "Schedule_id" });
            DropIndex("dbo.UserProfiles", new[] { "Field_FieldID" });
            DropIndex("dbo.UserProfiles", new[] { "Course_CourseID" });
            DropTable("dbo.UserProfiles");
        }
    }
}
