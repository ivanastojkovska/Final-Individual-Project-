namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Field_FieldID", "dbo.Fields");
            DropIndex("dbo.Courses", new[] { "Field_FieldID" });
            RenameColumn(table: "dbo.Courses", name: "Field_FieldID", newName: "FieldID");
            AlterColumn("dbo.Courses", "FieldID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "FieldID");
            AddForeignKey("dbo.Courses", "FieldID", "dbo.Fields", "FieldID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "FieldID", "dbo.Fields");
            DropIndex("dbo.Courses", new[] { "FieldID" });
            AlterColumn("dbo.Courses", "FieldID", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "FieldID", newName: "Field_FieldID");
            CreateIndex("dbo.Courses", "Field_FieldID");
            AddForeignKey("dbo.Courses", "Field_FieldID", "dbo.Fields", "FieldID");
        }
    }
}
