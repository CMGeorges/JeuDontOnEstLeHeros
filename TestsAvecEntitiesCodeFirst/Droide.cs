﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestsAvecEntitiesCodeFirst
{
    [Table("Droide")]
    class Droide
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        //public Arme Arme { get; set; }


    }
}
