using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Data.Models
{
    public class Question
    {

        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }


        public List<Answer> MyAnswers { get; set; }
        #endregion
    }
}
