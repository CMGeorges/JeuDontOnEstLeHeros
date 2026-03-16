using System.Collections.Generic;
using System.Linq;
using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PratiqueUdemy.Controllers;

namespace TestWebUI
{
    [TestClass]
    public class AventureControllerTests
    {
        [TestMethod]
        public void Index_RetourneLesAventuresEtLeTitre()
        {
            using DefaultContext context = CreateContext();
            context.Aventures.AddRange(
                new Aventure { Id = 1, Titre = "La foret" },
                new Aventure { Id = 2, Titre = "Le donjon" });
            context.SaveChanges();

            AventureController controller = new AventureController(context);

            ViewResult result = (ViewResult)controller.Index();
            List<Aventure> model = ((IEnumerable<Aventure>)result.Model).ToList();

            Assert.AreEqual("Aventures", result.ViewData["MonTitre"]);
            CollectionAssert.AreEqual(
                new[] { "La foret", "Le donjon" },
                model.Select(item => item.Titre).ToArray());
        }

        [TestMethod]
        public void Create_RetourneUneVue()
        {
            using DefaultContext context = CreateContext();
            AventureController controller = new AventureController(context);

            ActionResult result = controller.Create();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Edit_RetourneUneVueAvecLIdentifiantCommeModele()
        {
            using DefaultContext context = CreateContext();
            AventureController controller = new AventureController(context);

            ViewResult result = (ViewResult)controller.Edit(42);

            Assert.AreEqual(42, result.Model);
        }

        private static DefaultContext CreateContext()
        {
            DbContextOptions<DefaultContext> options = new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            return new DefaultContext(options);
        }
    }
}
