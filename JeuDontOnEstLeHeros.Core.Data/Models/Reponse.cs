using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Proposition")]
    public class Reponse
    {
        #region Propriétés
        /// <summary>
        /// Id de la BD
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Proposition de reponse
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Question relié
        /// </summary>
        public int QuestionId { get; set; }
        #endregion
    }
}
