using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Aventure")]
    public class Aventure
    {
        #region Propriétés
        /// <summary>
        /// 
        /// C'est le Id de chaque aventure 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// C'est le titre de l'aventure
        /// </summary>
        public string Titre { get; set; }
        #endregion

    }
}
