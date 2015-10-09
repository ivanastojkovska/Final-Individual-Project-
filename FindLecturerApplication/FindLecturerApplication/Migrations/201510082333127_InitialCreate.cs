namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Intro = c.String(),
                        Content = c.String(nullable: false),
                        Tags = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
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
                        isApproved = c.Boolean(nullable: false),
                        Event_id = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Event_id)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Lecturer_VideoID = c.Int(),
                        Field_FieldID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_VideoID)
                .ForeignKey("dbo.Fields", t => t.Field_FieldID)
                .Index(t => t.Lecturer_VideoID)
                .Index(t => t.Field_FieldID);
            
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
                "dbo.Fields",
                c => new
                    {
                        FieldID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Lecturer_VideoID = c.Int(),
                    })
                .PrimaryKey(t => t.FieldID)
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_VideoID)
                .Index(t => t.Lecturer_VideoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lecturers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Fields", "Lecturer_VideoID", "dbo.Lecturers");
            DropForeignKey("dbo.Courses", "Field_FieldID", "dbo.Fields");
            DropForeignKey("dbo.Lecturers", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Courses", "Lecturer_VideoID", "dbo.Lecturers");
            DropForeignKey("dbo.BlogPosts", "User_ID", "dbo.Users");
            DropIndex("dbo.Fields", new[] { "Lecturer_VideoID" });
            DropIndex("dbo.Courses", new[] { "Field_FieldID" });
            DropIndex("dbo.Courses", new[] { "Lecturer_VideoID" });
            DropIndex("dbo.Lecturers", new[] { "User_ID" });
            DropIndex("dbo.Lecturers", new[] { "Event_id" });
            DropIndex("dbo.BlogPosts", new[] { "User_ID" });
            DropTable("dbo.Fields");
            DropTable("dbo.Events");
            DropTable("dbo.Courses");
            DropTable("dbo.Lecturers");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Users");
        }
    }
}
