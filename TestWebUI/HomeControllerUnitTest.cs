using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using PratiqueUdemy.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestWebUI
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public void TestAboutIsOk()
        {
            HomeController controller = new HomeController();
            var result = controller.About();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult.ViewData["Message"]);
            Assert.IsNotNull(viewResult.ViewData["Message"].ToString() == "Your application description page.");

        }
    }
}
