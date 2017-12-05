namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21stNov : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipment", "StudentID", "dbo.Student");
            DropIndex("dbo.Equipment", new[] { "StudentID" });
            AlterColumn("dbo.Equipment", "StudentID", c => c.Int());
            CreateIndex("dbo.Equipment", "StudentID");
            AddForeignKey("dbo.Equipment", "StudentID", "dbo.Student", "StudentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "StudentID", "dbo.Student");
            DropIndex("dbo.Equipment", new[] { "StudentID" });
            AlterColumn("dbo.Equipment", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Equipment", "StudentID");
            AddForeignKey("dbo.Equipment", "StudentID", "dbo.Student", "StudentID", cascadeDelete: true);
        }
    }
}
