namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25thSeptember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        DateAssigned = c.DateTime(nullable: false),
                        EquipmentName = c.String(),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "StudentID", "dbo.Student");
            DropIndex("dbo.Equipment", new[] { "StudentID" });
            DropTable("dbo.Student");
            DropTable("dbo.Equipment");
        }
    }
}
