namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItensCompraTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItensCompra",
                c => new
                    {
                        CompraId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Byte(nullable: false),
                        PrecoProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.CompraId, t.ProdutoId })
                .ForeignKey("dbo.Compras", t => t.CompraId)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId)
                .Index(t => t.CompraId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensCompra", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.ItensCompra", "CompraId", "dbo.Compras");
            DropIndex("dbo.ItensCompra", new[] { "ProdutoId" });
            DropIndex("dbo.ItensCompra", new[] { "CompraId" });
            DropTable("dbo.ItensCompra");
        }
    }
}
