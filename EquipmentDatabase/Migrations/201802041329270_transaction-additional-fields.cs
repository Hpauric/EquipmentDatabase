namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionadditionalfields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(),
                        EquipmentID = c.Int(),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Equipment", t => t.EquipmentID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.EquipmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment");
            DropIndex("dbo.Transaction", new[] { "EquipmentID" });
            DropIndex("dbo.Transaction", new[] { "StudentID" });
            DropTable("dbo.Transaction");
        }
    }
}
