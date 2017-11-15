using Microsoft.AspNet.Identity.EntityFramework;

namespace iMarket.MVC.Models
{
    public class iMarketContext : IdentityDbContext<ApplicationUser>
    {
        public iMarketContext()
            : base("iMarketDB", throwIfV1Schema: false)
        {
        }

        public static iMarketContext Create()
        {
            return new iMarketContext();
        }
    }
}