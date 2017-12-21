namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordstatusnotesaddedtoequipmentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "Password", c => c.String());
            AddColumn("dbo.Equipment", "Status", c => c.String());
            AddColumn("dbo.Equipment", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "Notes");
            DropColumn("dbo.Equipment", "Status");
            DropColumn("dbo.Equipment", "Password");
        }
    }
}
