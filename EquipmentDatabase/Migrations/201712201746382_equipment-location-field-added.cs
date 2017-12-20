namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipmentlocationfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "Location");
        }
    }
}
