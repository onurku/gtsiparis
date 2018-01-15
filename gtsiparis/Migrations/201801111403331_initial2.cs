namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.IdentityUsers", "RefEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.IdentityUsers", "RefEmail");
        }
    }
}
