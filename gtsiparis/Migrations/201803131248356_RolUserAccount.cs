namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolUserAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.IdentityUsers", "WebAdmin", c => c.Boolean());
            AddColumn("gtadmin.IdentityUsers", "Turetici", c => c.Boolean());
            AddColumn("gtadmin.IdentityUsers", "GrupAdmin", c => c.Boolean());
            AddColumn("gtadmin.IdentityUsers", "Uretici", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.IdentityUsers", "Uretici");
            DropColumn("gtadmin.IdentityUsers", "GrupAdmin");
            DropColumn("gtadmin.IdentityUsers", "Turetici");
            DropColumn("gtadmin.IdentityUsers", "WebAdmin");
        }
    }
}
