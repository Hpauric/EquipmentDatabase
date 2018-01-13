namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        DatePurchased = c.DateTime(nullable: false),
                        DateAssigned = c.DateTime(),
                        EquipmentType = c.String(nullable: false),
                        ModelName = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                        ServiceTag = c.String(),
                        Software = c.String(),
                        Password = c.String(),
                        Notes = c.String(),
                        StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Student", t => t.StudentID)
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
