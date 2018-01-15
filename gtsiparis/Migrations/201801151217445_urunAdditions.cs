namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urunAdditions : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.Urun", "Mesafe", c => c.Int());
            AddColumn("gtadmin.Urun", "AlinacakLokasyon", c => c.String());
            AddColumn("gtadmin.Urun", "UretimBolge", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.Urun", "UretimBolge");
            DropColumn("gtadmin.Urun", "AlinacakLokasyon");
            DropColumn("gtadmin.Urun", "Mesafe");
        }
    }
}
