using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using iMarket.Models;

namespace iMarket.Infra.Context
{
    public class IMarketDBContext : IdentityDbContext<User>
    {
        public DbSet<Departamento> Departamentos{ get; set; }
        public DbSet<Consumidor> Consumidores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Supermercado> Supermercados { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public IMarketDBContext()
            : base("iMarketDB", throwIfV1Schema: false)
        {
        }

        public static IMarketDBContext Create()
        {
            return new IMarketDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));
        }
    }
}