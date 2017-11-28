namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnIdCategoriaToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.Produtos", new[] { "DepartamentoId" });
            DropPrimaryKey("dbo.Departamentos");
            AlterColumn("dbo.Departamentos", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Produtos", "DepartamentoId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Departamentos", "Id");
            CreateIndex("dbo.Produtos", "DepartamentoId");
            AddForeignKey("dbo.Produtos", "DepartamentoId", "dbo.Departamentos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.Produtos", new[] { "DepartamentoId" });
            DropPrimaryKey("dbo.Departamentos");
            AlterColumn("dbo.Produtos", "DepartamentoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Departamentos", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departamentos", "Id");
            CreateIndex("dbo.Produtos", "DepartamentoId");
            AddForeignKey("dbo.Produtos", "DepartamentoId", "dbo.Departamentos", "Id");
        }
    }
}
