namespace ArmyTechTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameTypeIdInCouresModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "CouseType_Id", newName: "CouseTypeId");
            RenameIndex(table: "dbo.Courses", name: "IX_CouseType_Id", newName: "IX_CouseTypeId");
            DropColumn("dbo.Courses", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Type", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Courses", name: "IX_CouseTypeId", newName: "IX_CouseType_Id");
            RenameColumn(table: "dbo.Courses", name: "CouseTypeId", newName: "CouseType_Id");
        }
    }
}
