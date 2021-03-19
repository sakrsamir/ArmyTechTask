namespace ArmyTechTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGovModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GovernorateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId)
                .Index(t => t.GovernorateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Neighborhoods", "GovernorateId", "dbo.Governorates");
            DropIndex("dbo.Neighborhoods", new[] { "GovernorateId" });
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.Governorates");
        }
    }
}
