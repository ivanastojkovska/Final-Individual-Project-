namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.UserProfiles", "Event_id", "dbo.Events");
            DropForeignKey("dbo.UserProfiles", "Field_FieldID", "dbo.Fields");
            DropForeignKey("dbo.Users", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "Course_CourseID" });
            DropIndex("dbo.UserProfiles", new[] { "Event_id" });
            DropIndex("dbo.UserProfiles", new[] { "Field_FieldID" });
            DropIndex("dbo.Users", new[] { "UserProfile_ProfileID" });
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_time = c.Int(nullable: false),
                        end_time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Courses", "User_ID", c => c.Int());
            AddColumn("dbo.Fields", "User_ID", c => c.Int());
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "FormalEducation", c => c.String(nullable: false));
            AddColumn("dbo.Users", "ProfesionalExperience", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Skills", c => c.String());
            AddColumn("dbo.Users", "UserImage", c => c.String());
            AddColumn("dbo.Users", "Schedule_id", c => c.Int());
            CreateIndex("dbo.Courses", "User_ID");
            CreateIndex("dbo.Fields", "User_ID");
            CreateIndex("dbo.Users", "Schedule_id");
            AddForeignKey("dbo.Courses", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Fields", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Users", "Schedule_id", "dbo.Schedules", "id");
            DropColumn("dbo.Users", "UserProfile_ProfileID");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                        Event_id = c.Int(),
                        Field_FieldID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            AddColumn("dbo.Users", "UserProfile_ProfileID", c => c.Int());
            DropForeignKey("dbo.Users", "Schedule_id", "dbo.Schedules");
            DropForeignKey("dbo.Fields", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Courses", "User_ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Schedule_id" });
            DropIndex("dbo.Fields", new[] { "User_ID" });
            DropIndex("dbo.Courses", new[] { "User_ID" });
            DropColumn("dbo.Users", "Schedule_id");
            DropColumn("dbo.Users", "UserImage");
            DropColumn("dbo.Users", "Skills");
            DropColumn("dbo.Users", "ProfesionalExperience");
            DropColumn("dbo.Users", "FormalEducation");
            DropColumn("dbo.Users", "BirthDate");
            DropColumn("dbo.Fields", "User_ID");
            DropColumn("dbo.Courses", "User_ID");
            DropTable("dbo.Schedules");
            CreateIndex("dbo.Users", "UserProfile_ProfileID");
            CreateIndex("dbo.UserProfiles", "Field_FieldID");
            CreateIndex("dbo.UserProfiles", "Event_id");
            CreateIndex("dbo.UserProfiles", "Course_CourseID");
            AddForeignKey("dbo.Users", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
            AddForeignKey("dbo.UserProfiles", "Field_FieldID", "dbo.Fields", "FieldID");
            AddForeignKey("dbo.UserProfiles", "Event_id", "dbo.Events", "id");
            AddForeignKey("dbo.UserProfiles", "Course_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
