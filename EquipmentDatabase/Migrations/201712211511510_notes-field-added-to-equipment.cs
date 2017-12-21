namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notesfieldaddedtoequipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "ServiceTag", c => c.String());
            AddColumn("dbo.Equipment", "Software", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "Software");
            DropColumn("dbo.Equipment", "ServiceTag");
        }
    }
}
