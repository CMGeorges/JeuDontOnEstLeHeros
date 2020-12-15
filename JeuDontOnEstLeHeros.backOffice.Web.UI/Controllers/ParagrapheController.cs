using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHeros.backOffice.Web.UI.Controllers
{
    public class ParagrapheController : Controller
    {

        #region Champs privés
        private readonly DefaultContext _context = null;
        #endregion

        #region Contructeurs
         public ParagrapheController(DefaultContext context)
        {
            this._context = context;
        }

        #endregion


        #region Méthodes publiques


        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Paragraphe paragraphe)
        {
            if (ModelState.IsValid)
            {
                this._context.Paragraphes.Add(paragraphe);
                this._context.SaveChanges();

            }
            
            return this.View();
        }
        public ActionResult Edit(int id)
        {
            Paragraphe paragraphe = null;

            paragraphe = this._context.Paragraphes.First(item => item.Id == id);
            

            return this.View(paragraphe);

        }
        [HttpPost]
        public ActionResult Edit(Paragraphe paragraphe)
        {
            this._context.Paragraphes.Update(paragraphe);
            //pour la modification d'un seul champs
           /* this._context.Attach<Paragraphe>(paragraphe);
            this._context.Entry(paragraphe).Property(item => item.Titre).IsModified= true;
           */

            this._context.SaveChanges();
            return this.View(paragraphe);
        }



        
        #endregion
    }
}
