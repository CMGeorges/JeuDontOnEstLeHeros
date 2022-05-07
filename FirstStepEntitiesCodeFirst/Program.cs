// See https://aka.ms/new-console-template for more information



using FirstStepEntitiesCodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder builder = new ConfigurationBuilder();

builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");
   
var config = builder.Build();

var connectionString = config.GetConnectionString("BackOfficeDb");


DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

optionsBuilder.UseMySQL(connectionString);

using (DBContext dbContext = new DBContext(optionsBuilder.Options))
{
    var query = from droide in dbContext.Droides
              select droide;

    foreach (var item in query.ToList())
    {
        Console.WriteLine(item.Matricule);
    }

}
