using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.backOffice.Web.UI.Controllers
{
    public class QuestionController : Controller
    {

        #region Champs privés
        private readonly DefaultContext _context = null;
        #endregion


        #region Contructeurs
        public QuestionController(DefaultContext context)
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
            SetParagraphesList();
            return this.View();
        }

       

        [HttpPost]
        public IActionResult Add(Question question)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Questions.Add(question);
                this._context.SaveChanges();
            }

            SetParagraphesList();

            return this.View(question);
        }


        #region Private Méthodes
        private void SetParagraphesList()
        {
            this.ViewBag.myParagraphes = this._context.Paragraphes.ToList();
        }
        #endregion
    }
}
