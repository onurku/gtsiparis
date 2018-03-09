namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNickField : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.IdentityUsers", "UserNick", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.IdentityUsers", "UserNick");
        }
    }
}
