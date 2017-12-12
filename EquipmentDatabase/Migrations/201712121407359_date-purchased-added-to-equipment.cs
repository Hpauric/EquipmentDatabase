namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepurchasedaddedtoequipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "DatePurchased", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "DatePurchased");
        }
    }
}
