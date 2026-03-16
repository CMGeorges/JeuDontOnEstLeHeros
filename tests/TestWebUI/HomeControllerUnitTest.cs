using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using PratiqueUdemy.Controllers;
using PratiqueUdemy.Models;

namespace TestWebUI
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public void About_RetourneUneVueEtLeMessageAttendu()
        {
            HomeController controller = new HomeController();
            var result = controller.About();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;

            Assert.AreEqual("Your application description page.", viewResult.ViewData["Message"]);
        }

        [TestMethod]
        public void Index_RetourneUneVueEtDefinitLeTitreDansLeViewBag()
        {
            HomeController controller = new HomeController(new NullLogger<HomeController>());

            ViewResult result = (ViewResult)controller.Index();

            Assert.AreEqual("ceci est le titre", result.ViewData["monTitre"]);
        }

        [TestMethod]
        public void Privacy_RetourneUneVue()
        {
            HomeController controller = new HomeController();

            IActionResult result = controller.Privacy();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Error_UtiliseLIdentifiantDeLActiviteQuandDisponible()
        {
            HomeController controller = new HomeController();
            using ActivityScope activity = new ActivityScope();

            ViewResult result = (ViewResult)controller.Error();
            ErrorViewModel model = (ErrorViewModel)result.Model;

            Assert.AreEqual(activity.Id, model.RequestId);
            Assert.IsTrue(model.ShowRequestId);
        }

        [TestMethod]
        public void Error_UtiliseLeTraceIdentifierHttpQuandAucuneActiviteNExiste()
        {
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    TraceIdentifier = "trace-id"
                }
            };

            ViewResult result = (ViewResult)controller.Error();
            ErrorViewModel model = (ErrorViewModel)result.Model;

            Assert.AreEqual("trace-id", model.RequestId);
        }

        private sealed class ActivityScope : IDisposable
        {
            private readonly System.Diagnostics.Activity _activity = new System.Diagnostics.Activity("test");

            public ActivityScope()
            {
                _activity.Start();
            }

            public string Id => _activity.Id;

            public void Dispose()
            {
                _activity.Stop();
            }
        }
    }
}
