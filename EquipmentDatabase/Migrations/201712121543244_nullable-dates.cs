namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabledates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipment", "DatePurchased", c => c.DateTime());
            AlterColumn("dbo.Equipment", "DateAssigned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipment", "DateAssigned", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Equipment", "DatePurchased", c => c.DateTime(nullable: false));
        }
    }
}
