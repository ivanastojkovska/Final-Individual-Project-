namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "CourseID", "dbo.Courses");
            DropIndex("dbo.UserProfiles", new[] { "CourseID" });
            RenameColumn(table: "dbo.UserProfiles", name: "CourseID", newName: "Course_CourseID");
            AlterColumn("dbo.UserProfiles", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.UserProfiles", "Course_CourseID");
            AddForeignKey("dbo.UserProfiles", "Course_CourseID", "dbo.Courses", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.UserProfiles", new[] { "Course_CourseID" });
            AlterColumn("dbo.UserProfiles", "Course_CourseID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserProfiles", name: "Course_CourseID", newName: "CourseID");
            CreateIndex("dbo.UserProfiles", "CourseID");
            AddForeignKey("dbo.UserProfiles", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
