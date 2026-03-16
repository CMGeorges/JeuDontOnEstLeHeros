using System;
using System.Net;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PratiqueUdemy;

namespace TestWebUI
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void ConfigureServices_EnregistreLesServicesAttendus()
        {
            ServiceCollection services = new ServiceCollection();
            Startup startup = new Startup(BuildConfiguration());

            startup.ConfigureServices(services);
            using ServiceProvider provider = services.BuildServiceProvider();

            CookiePolicyOptions cookiePolicy = provider.GetRequiredService<IOptions<CookiePolicyOptions>>().Value;
            DefaultContext context = provider.GetRequiredService<DefaultContext>();

            Assert.IsTrue(cookiePolicy.CheckConsentNeeded(new DefaultHttpContext()));
            Assert.AreEqual(SameSiteMode.None, cookiePolicy.MinimumSameSitePolicy);
            Assert.AreEqual("Microsoft.EntityFrameworkCore.SqlServer", context.Database.ProviderName);
        }

        [TestMethod]
        public async Task Configure_ConstruitLePipelineEnDeveloppement()
        {
            using IHost host = await BuildHostAsync(Environments.Development);
            HttpStatusCode statusCode = (await host.GetTestClient().GetAsync("/mes-aventures")).StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }

        [TestMethod]
        public async Task Configure_ConstruitLePipelineEnProduction()
        {
            using IHost host = await BuildHostAsync(Environments.Production);
            HttpStatusCode statusCode = (await host.GetTestClient().GetAsync("/mes-aventures")).StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }

        [TestMethod]
        public void Program_CreateHostBuilder_RetourneUnHostBuilder()
        {
            IHostBuilder hostBuilder = Program.CreateHostBuilder(Array.Empty<string>());

            Assert.IsNotNull(hostBuilder);
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new System.Collections.Generic.KeyValuePair<string, string>(
                        "ConnectionStrings:DefaultContext",
                        "Server=(localdb)\\mssqllocaldb;Database=JeuDontOnEstLeHero.Tests;Trusted_Connection=True;")
                })
                .Build();
        }

        private static async Task<IHost> BuildHostAsync(string environment)
        {
            string applicationRoot = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "src", "PratiqueUdemy"));

            IHost host = await Program.CreateHostBuilder(Array.Empty<string>())
                .UseEnvironment(environment)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddInMemoryCollection(new[]
                    {
                        new System.Collections.Generic.KeyValuePair<string, string>(
                            "ConnectionStrings:DefaultContext",
                            "Server=(localdb)\\mssqllocaldb;Database=JeuDontOnEstLeHero.Tests;Trusted_Connection=True;")
                    });
                })
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseContentRoot(applicationRoot);
                    webBuilder.UseTestServer();
                    webBuilder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DbContextOptions<DefaultContext>));
                        services.RemoveAll(typeof(DefaultContext));
                        services.AddDbContext<DefaultContext>(options =>
                            options.UseInMemoryDatabase($"startup-tests-{environment}"));
                    });
                })
                .StartAsync();

            return host;
        }
    }
}
