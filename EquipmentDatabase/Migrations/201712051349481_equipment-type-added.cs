namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipmenttypeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "EquipmentType", c => c.String());
            AddColumn("dbo.Equipment", "ModelName", c => c.String());
            DropColumn("dbo.Equipment", "EquipmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipment", "EquipmentName", c => c.String());
            DropColumn("dbo.Equipment", "ModelName");
            DropColumn("dbo.Equipment", "EquipmentType");
        }
    }
}
