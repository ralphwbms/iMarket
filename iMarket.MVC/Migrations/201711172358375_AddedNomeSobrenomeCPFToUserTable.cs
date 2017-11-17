namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNomeSobrenomeCPFToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Nome", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Users", "Sobrenome", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Users", "CPF", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CPF");
            DropColumn("dbo.Users", "Sobrenome");
            DropColumn("dbo.Users", "Nome");
        }
    }
}
