namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredfieldsequipment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipment", "DatePurchased", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Equipment", "EquipmentType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipment", "EquipmentType", c => c.String());
            AlterColumn("dbo.Equipment", "DatePurchased", c => c.DateTime());
        }
    }
}
