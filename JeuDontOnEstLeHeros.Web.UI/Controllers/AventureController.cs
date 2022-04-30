using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHeros.Web.UI.Controllers
{
    public class AventureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
