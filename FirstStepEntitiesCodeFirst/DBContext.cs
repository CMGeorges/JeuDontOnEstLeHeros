using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepEntitiesCodeFirst
{
    public class DBContext : DbContext
    {
        public DbSet<Droide> Droides { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
