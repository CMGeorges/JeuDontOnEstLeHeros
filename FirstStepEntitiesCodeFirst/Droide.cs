using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepEntitiesCodeFirst
{
    public class Droide
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public Weapon Weapon { get; set; }
    }
}
