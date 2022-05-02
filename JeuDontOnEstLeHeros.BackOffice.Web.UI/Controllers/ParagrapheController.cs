using JeuDontEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHeros.BackOffice.Web.UI.Controllers
{
    public class ParagrapheController : Controller
    {

        private List<Paragraphe> _paragrapheList = new List<Paragraphe>()
        {
            new Paragraphe() { Id = 0, Number = 1 , Title="Titre 1"   },
            new Paragraphe() { Id = 1, Number = 2 , Title="Titre 2"   },
            new Paragraphe() { Id = 2, Number = 3 , Title="Titre 3"   },
            new Paragraphe() { Id = 3, Number = 4 , Title="Titre 4"   },
        };

        #region Properties

        #endregion


        #region Ctor

        #endregion


        #region Public methods

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Paragraphe paragraphe)
        {

            return Json(paragraphe);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var paragraphe = _paragrapheList.FirstOrDefault(p => p.Id == Id);
            return View( paragraphe);
        }

        [HttpPut]
        public ActionResult Edit(Paragraphe paragraphe,int Id)
        {
            return View(paragraphe);
        }
        #endregion

        #region Private methods

        #endregion
       
    }
}
