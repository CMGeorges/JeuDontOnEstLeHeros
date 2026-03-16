using Microsoft.VisualStudio.TestTools.UnitTesting;
using PratiqueUdemy.Models;

namespace TestWebUI
{
    [TestClass]
    public class ErrorViewModelTests
    {
        [TestMethod]
        public void ShowRequestId_EstFauxQuandLaValeurEstVide()
        {
            ErrorViewModel model = new ErrorViewModel { RequestId = string.Empty };

            Assert.IsFalse(model.ShowRequestId);
        }

        [TestMethod]
        public void ShowRequestId_EstVraiQuandLaValeurExiste()
        {
            ErrorViewModel model = new ErrorViewModel { RequestId = "abc-123" };

            Assert.IsTrue(model.ShowRequestId);
        }
    }
}
