using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SEOManagement.Areas.Identity.Data;

namespace SEOManagement.Models
{
    public class SEOManagementContext : IdentityDbContext<ApplicationUser>
    {
        public SEOManagementContext(DbContextOptions<SEOManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
