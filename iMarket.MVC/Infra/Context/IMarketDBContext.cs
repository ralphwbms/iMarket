using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iMarket.Infra.Context
{
    public class IMarketDBContext : IdentityDbContext<ApplicationUser>
    {
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
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users", "dbo");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
        }
    }
}