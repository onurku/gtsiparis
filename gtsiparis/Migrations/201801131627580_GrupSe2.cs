namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrupSe2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("gtadmin.GrupIndeksi", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("gtadmin.GrupIndeksi", "UserId", c => c.Int());
        }
    }
}
