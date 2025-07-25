using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.backOffice.Web.UI.Controllers
{
    public class PropositionController : Controller
    {
        #region Champs privés
        private readonly DefaultContext _context = null;
        #endregion


        #region Contructeurs
        public PropositionController(DefaultContext context)
        {
            this._context = context;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            SetQuestionList();

            return this.View();
        }

        
        [HttpPost]
        public IActionResult Add(Reponse reponse)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Reponses.Add(reponse);
                this._context.SaveChanges();
            }

            SetQuestionList();


            return this.View(reponse);
        }


        #region private méthodes

        private void SetQuestionList()
        {
            this.ViewBag.QuestionList = this._context.Questions.ToList();
        }
        #endregion


    }
}
