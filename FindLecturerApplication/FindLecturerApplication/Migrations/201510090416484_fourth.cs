namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecturer_VideoID", "dbo.Lecturers");
            DropForeignKey("dbo.Lecturers", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Fields", "Lecturer_VideoID", "dbo.Lecturers");
            DropForeignKey("dbo.Lecturers", "User_ID", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "Lecturer_VideoID" });
            DropIndex("dbo.Fields", new[] { "Lecturer_VideoID" });
            DropIndex("dbo.Lecturers", new[] { "Event_id" });
            DropIndex("dbo.Lecturers", new[] { "User_ID" });
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        FormalEducation = c.String(nullable: false),
                        ProfesionalExperience = c.String(nullable: false),
                        Skills = c.String(),
                        UserImage = c.String(),
                        Event_id = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Event_id)
                .Index(t => t.User_ID);
            
            AddColumn("dbo.Courses", "UserProfile_ProfileID", c => c.Int());
            AddColumn("dbo.Fields", "UserProfile_ProfileID", c => c.Int());
            CreateIndex("dbo.Courses", "UserProfile_ProfileID");
            CreateIndex("dbo.Fields", "UserProfile_ProfileID");
            AddForeignKey("dbo.Courses", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
            AddForeignKey("dbo.Fields", "UserProfile_ProfileID", "dbo.UserProfiles", "ProfileID");
            DropColumn("dbo.Courses", "Lecturer_VideoID");
            DropColumn("dbo.Fields", "Lecturer_VideoID");
            DropTable("dbo.Lecturers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        FormalEducation = c.String(nullable: false),
                        ProfesionalExperience = c.String(nullable: false),
                        Skills = c.String(),
                        UserImage = c.String(),
                        Event_id = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID);
            
            AddColumn("dbo.Fields", "Lecturer_VideoID", c => c.Int());
            AddColumn("dbo.Courses", "Lecturer_VideoID", c => c.Int());
            DropForeignKey("dbo.UserProfiles", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Fields", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Courses", "UserProfile_ProfileID", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "User_ID" });
            DropIndex("dbo.UserProfiles", new[] { "Event_id" });
            DropIndex("dbo.Fields", new[] { "UserProfile_ProfileID" });
            DropIndex("dbo.Courses", new[] { "UserProfile_ProfileID" });
            DropColumn("dbo.Fields", "UserProfile_ProfileID");
            DropColumn("dbo.Courses", "UserProfile_ProfileID");
            DropTable("dbo.UserProfiles");
            CreateIndex("dbo.Lecturers", "User_ID");
            CreateIndex("dbo.Lecturers", "Event_id");
            CreateIndex("dbo.Fields", "Lecturer_VideoID");
            CreateIndex("dbo.Courses", "Lecturer_VideoID");
            AddForeignKey("dbo.Lecturers", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Fields", "Lecturer_VideoID", "dbo.Lecturers", "VideoID");
            AddForeignKey("dbo.Lecturers", "Event_id", "dbo.Events", "id");
            AddForeignKey("dbo.Courses", "Lecturer_VideoID", "dbo.Lecturers", "VideoID");
        }
    }
}
