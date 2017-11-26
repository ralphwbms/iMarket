namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNomeSobrenomeCPFFromUsersTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Nome");
            DropColumn("dbo.Users", "Sobrenome");
            DropColumn("dbo.Users", "CPF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CPF", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.Users", "Sobrenome", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Users", "Nome", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
