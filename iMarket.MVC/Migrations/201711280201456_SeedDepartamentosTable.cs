namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDepartamentosTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (1, N'Feira', N'Frutas, verduras, legumes...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (2, N'Mercearia', N'Arroz, Feijão, Massas...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (3, N'Açougue', N'Carnes, Embutidos...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (4, N'Bebidas', N'Refrigerantes, Sucos...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (5, N'Bebidas Alcóolicas', N'Vinhos, Cervejas...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (6, N'Diet e Light', N'Bebidas, Mercearia...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (7, N'Frios e Laticínios', N'Iogurtes, Sorvetes...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (8, N'Higiene Pessoal', N'Fralda, Sabonete...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (9, N'Limpeza', N'Álcol, Detergente...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (10, N'Bazar', N'Papelaria, Pilhas...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (11, N'Farmácia', N'Cotonetes, Band-aid...')");
            Sql("INSERT INTO [dbo].[Departamentos] ([Id], [Nome], [Descricao]) VALUES (12, N'Petshop', N'Rações, Petiscos...')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[Departamentos]");
        }
    }
}
