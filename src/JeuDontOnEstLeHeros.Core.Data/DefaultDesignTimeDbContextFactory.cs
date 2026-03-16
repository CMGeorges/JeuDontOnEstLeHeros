using JeuDontOnEstLeHeros.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jeudontonestleheros.Core.Data
{
    public class DefaultDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        private const string DefaultContextConnectionName = "DefaultContext";

        public DefaultContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                               .SetBasePath(path)
                               .AddJsonFile("appsettings.json");


            var config = builder.Build();

            var connectionString = config.GetConnectionString(DefaultContextConnectionName)
                ?? throw new InvalidOperationException(
                    $"Connection string '{DefaultContextConnectionName}' is missing.");

            DbContextOptionsBuilder<DefaultContext> optionBuilder = new DbContextOptionsBuilder<DefaultContext>();
            optionBuilder.UseSqlServer(connectionString); 

            return new DefaultContext(optionBuilder.Options);
        }
    }
}
