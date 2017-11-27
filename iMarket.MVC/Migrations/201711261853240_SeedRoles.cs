namespace iMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles (Id, Name) VALUES ('1', 'Admin')");
            Sql("INSERT INTO Roles (Id, Name) VALUES ('2', 'Consumidor')");
            Sql("INSERT INTO Roles (Id, Name) VALUES ('3', 'Supermercado')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Roles WHERE Id = '1')");
            Sql("DELETE FROM Roles WHERE Id = '2')");
            Sql("DELETE FROM Roles WHERE Id = '3')");
        }
    }
}
