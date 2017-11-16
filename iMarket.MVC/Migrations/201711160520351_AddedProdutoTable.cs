namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProdutoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoPromocional = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TemEstoque = c.Boolean(nullable: false),
                        DepartamentoId = c.Byte(nullable: false),
                        SupermercadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .ForeignKey("dbo.Supermercados", t => t.SupermercadoId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.SupermercadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "SupermercadoId", "dbo.Supermercados");
            DropForeignKey("dbo.Produtos", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.Produtos", new[] { "SupermercadoId" });
            DropIndex("dbo.Produtos", new[] { "DepartamentoId" });
            DropTable("dbo.Produtos");
        }
    }
}
