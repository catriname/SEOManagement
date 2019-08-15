using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEOManagement.Areas.Identity.Data;
using SEOManagement.Models;
using System;

[assembly: HostingStartup(typeof(SEOManagement.Areas.Identity.IdentityHostingStartup))]
namespace SEOManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddDbContext<SEOManagementContext>(options =>
                //options.UseSqlServer(System.Environment.GetEnvironmentVariable("SQLAZURECONNSTR_Production")));

                services.AddDbContext<SEOManagementContext>(options =>
                options.UseSqlServer(System.Environment.GetEnvironmentVariable("stDevProductConnectionString")));

                services.AddDefaultIdentity<ApplicationUser>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    config.Lockout.MaxFailedAccessAttempts = 5;
                    config.Lockout.AllowedForNewUsers = true;
                    config.User.RequireUniqueEmail = true;
                })
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<SEOManagementContext>();
            });
        }
    }
}