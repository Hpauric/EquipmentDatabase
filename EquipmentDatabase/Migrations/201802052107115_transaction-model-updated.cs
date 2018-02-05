namespace EquipmentDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmodelupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "Note");
        }
    }
}
