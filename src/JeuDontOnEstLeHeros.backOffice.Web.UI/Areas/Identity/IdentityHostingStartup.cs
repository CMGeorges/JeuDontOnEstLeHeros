using System;
using JeuDontOnEstLeHeros.backOffice.Web.UI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JeuDontOnEstLeHeros.backOffice.Web.UI.Areas.Identity.IdentityHostingStartup))]
namespace JeuDontOnEstLeHeros.backOffice.Web.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<JeuDontOnEstLeHerosbackOfficeWebUIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("JeuDontOnEstLeHerosbackOfficeWebUIContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<JeuDontOnEstLeHerosbackOfficeWebUIContext>();
            });
        }
    }
}