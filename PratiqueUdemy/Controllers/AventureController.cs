using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using PratiqueUdemy.Models;

namespace PratiqueUdemy.Controllers
{
    public class AventureController : Controller
    {
        private readonly DefaultContext _context = null;
        public AventureController(DefaultContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            this.ViewBag.MonTitre = "Aventures";

            var query = from item in this._context.Aventures
                        select item;


            return View(query.ToList());
        }
        public ActionResult Create()
        {
            return this.View();
        }   
        
        [HttpPost]
        public ActionResult Create(Aventure aventure)
        {

            if (this.ModelState.IsValid)//validation du model : Aventure
            {
                this._context.Aventures.Add(aventure);//on rajoute la nouvelle aventure 
                this._context.SaveChanges();


                return this.RedirectToAction("BeginNewOne");

            }
            return this.View();
        }
        
        public ActionResult BeginNewOne()
        {

            return View();
        }
        
        public ActionResult Edit(int id)
        {
            return this.View(id);
        }
    }
}
