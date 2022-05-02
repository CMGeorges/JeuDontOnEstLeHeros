using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Data.Models
{
    public class Paragraphe
    {

        #region Properties
        public int Id { get; set; }
        public int Number { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public Question MyQuestion { get; set; }
        #endregion
    }
}
