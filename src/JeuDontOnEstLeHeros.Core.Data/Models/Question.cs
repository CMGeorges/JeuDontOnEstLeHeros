using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Question")]
    public class Question
    {
        #region Propriétés
        /// <summary>
        /// Id de l'instance
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Titre de la question
        /// </summary>
        public string Titre { get; set; }
        
        /// <summary>
        /// Le Id du paragraphe
        /// </summary>        
        public int ParagrapheId { get; set; }

        
        /// <summary>
        /// Liste de reponses
        /// </summary>
        public List<Reponse> MesResponses { get; set; }
        #endregion


    }
}
