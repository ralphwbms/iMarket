namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumidores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Sobrenome = c.String(nullable: false, maxLength: 80),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Descricao = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Tipo = c.String(nullable: false, maxLength: 80),
                        Logradouro = c.String(nullable: false, maxLength: 80),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(nullable: false, maxLength: 60),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        CEP = c.String(nullable: false, maxLength: 8),
                        UF = c.String(nullable: false, maxLength: 2),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        ConsumidorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumidores", t => t.ConsumidorId)
                .Index(t => t.ConsumidorId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Supermercados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 80),
                        NomeFantasia = c.String(nullable: false, maxLength: 80),
                        CNPJ = c.String(nullable: false, maxLength: 14),
                        Logradouro = c.String(nullable: false, maxLength: 80),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(nullable: false, maxLength: 60),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        CEP = c.String(nullable: false, maxLength: 8),
                        UF = c.String(nullable: false, maxLength: 2),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supermercados", "UsuarioId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Enderecos", "ConsumidorId", "dbo.Consumidores");
            DropForeignKey("dbo.Consumidores", "UsuarioId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.Supermercados", new[] { "UsuarioId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Enderecos", new[] { "ConsumidorId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Consumidores", new[] { "UsuarioId" });
            DropTable("dbo.Supermercados");
            DropTable("dbo.Roles");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Departamentos");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Consumidores");
        }
    }
}
