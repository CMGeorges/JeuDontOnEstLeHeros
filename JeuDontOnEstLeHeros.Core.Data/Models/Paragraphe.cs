using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Paragraphe")]
   public class Paragraphe
    {
        #region Propriétés
        
        /// <summary>
        /// Id venant de la BD
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champs ne peut¨être vide")]
        [Range(1,999999)]
        /// <summary>
        /// numéro à aficher pour le jeu
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// 
        /// C'est le titre du paragraphe
        /// 
        /// </summary>
        [Required(AllowEmptyStrings =false,ErrorMessage ="Un titre est obligatoire")]
        public string Titre { get; set; }

        /// <summary>
        /// Description du paragraphe
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage ="Veuillez mettre une description du paragraphe")]
        public string Description { get; set; }

        
        /// <summary>
        /// Question du paragraphe
        /// </summary>
        public Question MaQuestion { get; set; }
        #endregion
    }
}
