namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertdatabasegeneratedequipmentoption : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment");
            DropPrimaryKey("dbo.Equipment");
            AlterColumn("dbo.Equipment", "EquipmentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Equipment", "EquipmentID");
            AddForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment");
            DropPrimaryKey("dbo.Equipment");
            AlterColumn("dbo.Equipment", "EquipmentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Equipment", "EquipmentID");
            AddForeignKey("dbo.Transaction", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
        }
    }
}
