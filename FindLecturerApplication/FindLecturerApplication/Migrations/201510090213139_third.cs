namespace FindLecturerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "isApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lecturers", "isApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lecturers", "isApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "isApproved");
        }
    }
}
