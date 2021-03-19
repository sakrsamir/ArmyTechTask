namespace ArmyTechTask.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCourseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        CouseType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTypes", t => t.CouseType_Id)
                .Index(t => t.CouseType_Id);
            
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CouseType_Id", "dbo.CourseTypes");
            DropIndex("dbo.Courses", new[] { "CouseType_Id" });
            DropTable("dbo.CourseTypes");
            DropTable("dbo.Courses");
        }
    }
}
