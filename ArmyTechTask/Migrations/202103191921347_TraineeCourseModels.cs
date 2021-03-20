namespace ArmyTechTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraineeCourseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTrainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TraineeId = c.Int(nullable: false),
                        CourseDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TraineeId);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GovernorateId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId, cascadeDelete: true)
                .ForeignKey("dbo.Neighborhoods", t => t.NeighborhoodId, cascadeDelete: true)
                .Index(t => t.GovernorateId)
                .Index(t => t.NeighborhoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTrainees", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.Trainees", "NeighborhoodId", "dbo.Neighborhoods");
            DropForeignKey("dbo.Trainees", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.CourseTrainees", "CourseId", "dbo.Courses");
            DropIndex("dbo.Trainees", new[] { "NeighborhoodId" });
            DropIndex("dbo.Trainees", new[] { "GovernorateId" });
            DropIndex("dbo.CourseTrainees", new[] { "TraineeId" });
            DropIndex("dbo.CourseTrainees", new[] { "CourseId" });
            DropTable("dbo.Trainees");
            DropTable("dbo.CourseTrainees");
        }
    }
}
