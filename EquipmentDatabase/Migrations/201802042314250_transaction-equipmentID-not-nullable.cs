namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionequipmentIDnotnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment");
            DropIndex("dbo.Transaction", new[] { "EquipmentID" });
            AlterColumn("dbo.Transaction", "EquipmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "EquipmentID");
            AddForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment");
            DropIndex("dbo.Transaction", new[] { "EquipmentID" });
            AlterColumn("dbo.Transaction", "EquipmentID", c => c.Int());
            CreateIndex("dbo.Transaction", "EquipmentID");
            AddForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment", "EquipmentID");
        }
    }
}
