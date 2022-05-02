// See https://aka.ms/new-console-template for more information



using FirstStepEntitiesCodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder builder = new ConfigurationBuilder();


var config = builder.Build();

config.GetConnectionString("BackOfficeDb");


DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

using (DBContext dbContext = new DBContext(optionsBuilder.Options))
{
    var query = from droide in dbContext.Droides
              select droide;

    foreach (var item in query.ToList())
    {
        Console.WriteLine(item.Matricule);
    }

}
