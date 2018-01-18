namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SipariseTutarEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.Siparis", "Tutar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.Siparis", "Tutar");
        }
    }
}
