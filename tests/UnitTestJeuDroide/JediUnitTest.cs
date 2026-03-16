using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestJeuDroide
{
    [TestClass]
    public class JediUnitTest
    {
        [TestMethod]
        public void Attaquer_RetireCinquantePointsQuandLaCibleExiste()
        {
            ExempleJedi.Jedi jedi = new ExempleJedi.Jedi();
            ExempleJedi.Droide droide = new ExempleJedi.Droide
            {
                PointDeVie = 100
            };

            jedi.Attaquer(droide);

            Assert.AreEqual(50, droide.PointDeVie);
        }

        [TestMethod]
        public void Attaquer_NeLancePasExceptionQuandLaCibleEstNulle()
        {
            ExempleJedi.Jedi jedi = new ExempleJedi.Jedi
            {
                PointsDeVie = 75
            };

            jedi.Attaquer(null);

            Assert.AreEqual(75, jedi.PointsDeVie);
        }

        [TestMethod]
        public void Proprietes_SontLisiblesEtModifiables()
        {
            ExempleJedi.Jedi jedi = new ExempleJedi.Jedi
            {
                PointsDeVie = 120
            };
            ExempleJedi.Droide droide = new ExempleJedi.Droide
            {
                PointDeVie = 80
            };

            Assert.AreEqual(120, jedi.PointsDeVie);
            Assert.AreEqual(80, droide.PointDeVie);
        }
    }
}
