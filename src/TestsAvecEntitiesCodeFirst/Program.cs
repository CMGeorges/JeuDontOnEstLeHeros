using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using System.IO;

namespace TestsAvecEntitiesCodeFirst
{
    class Program
    {
        private const string DefaultContextConnectionName = "DefaultContext";

        static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config =builder.Build();


            string connectionString = config.GetConnectionString(DefaultContextConnectionName)
                ?? throw new InvalidOperationException(
                    $"Connection string '{DefaultContextConnectionName}' is missing.");

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();


            optionsBuilder.UseSqlServer(connectionString);

            using (DefaultContext context = new DefaultContext(optionsBuilder.Options))
            {
                var query = from Droide in context.Droides
                            select Droide;
                foreach(Droide item in query.ToList())
                {
                    Console.WriteLine(item.Matricule);
                }
            } 

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
