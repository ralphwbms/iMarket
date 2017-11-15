using Microsoft.AspNet.Identity.EntityFramework;

namespace iMarket.MVC.Models
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
    }
}