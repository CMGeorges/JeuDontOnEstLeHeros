using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace UnitTestJeuDroide
{
    [TestClass]
    public class JediUnitTest
    {
        [TestMethod]
        public void TesterAttaquerToutEstOk()
        {

            ExempleJedi.Jedi jedi = new ExempleJedi.Jedi();
            ExempleJedi.Droide droide = new ExempleJedi.Droide(){
                PointDeVie = 100

            };

            jedi.Attaquer(droide);

            Assert.IsTrue(droide.PointDeVie == 50);

        }
    }
}
