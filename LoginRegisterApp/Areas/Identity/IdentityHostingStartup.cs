using System;
using LoginRegisterApp.Areas.Identity.Data;
using LoginRegisterApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LoginRegisterApp.Areas.Identity.IdentityHostingStartup))]
namespace LoginRegisterApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginRegisterDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginRegisterDbContextConnection")));

                services.AddDefaultIdentity<LoginRegisterAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LoginRegisterDbContext>();
            });
        }
    }
}