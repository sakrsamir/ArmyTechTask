namespace ArmyTechTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecoursesModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CourseTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseTypes", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
