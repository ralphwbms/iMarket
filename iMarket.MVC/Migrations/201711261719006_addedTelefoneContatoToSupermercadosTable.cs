namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTelefoneContatoToSupermercadosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supermercados", "TelefoneContato", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Supermercados", "Complemento", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supermercados", "Complemento", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Supermercados", "TelefoneContato");
        }
    }
}
