using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
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
    }
}
