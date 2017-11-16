namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComprasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHoraCompra = c.DateTime(nullable: false),
                        Situacao = c.String(nullable: false),
                        ValorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorFrete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataHoraAgendamentoEntrega = c.DateTime(nullable: false),
                        DataHoraEntrega = c.DateTime(nullable: false),
                        SupermercadoId = c.Int(nullable: false),
                        ConsumidorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumidores", t => t.ConsumidorId)
                .ForeignKey("dbo.Supermercados", t => t.SupermercadoId)
                .Index(t => t.SupermercadoId)
                .Index(t => t.ConsumidorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "SupermercadoId", "dbo.Supermercados");
            DropForeignKey("dbo.Compras", "ConsumidorId", "dbo.Consumidores");
            DropIndex("dbo.Compras", new[] { "ConsumidorId" });
            DropIndex("dbo.Compras", new[] { "SupermercadoId" });
            DropTable("dbo.Compras");
        }
    }
}
