using JeuDontEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHeros.Web.UI.Controllers
{
    public class AdventureController : Controller
    {
        private readonly ILogger<AdventureController> _logger;

        public AdventureController(ILogger<AdventureController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.myTitle = "Adventures";
            List<Adventure> adventureList = new List<Adventure>();

            adventureList.Add(new Adventure() { Id=1,Title="My first adventure"});
            adventureList.Add(new Adventure() { Id = 2, Title = "My Second adventure" });


            return View(adventureList);
        }
    }
}
