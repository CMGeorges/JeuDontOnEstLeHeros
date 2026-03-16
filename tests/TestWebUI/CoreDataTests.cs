using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using jeudontonestleheros.Core.Data;

namespace TestWebUI
{
    [TestClass]
    public class CoreDataTests
    {
        [TestMethod]
        public void DefaultContext_ExposeTousLesDbSets()
        {
            using DefaultContext context = CreateContext();

            Assert.IsNotNull(context.Aventures);
            Assert.IsNotNull(context.Paragraphes);
            Assert.IsNotNull(context.Reponses);
            Assert.IsNotNull(context.Questions);
        }

        [TestMethod]
        public void Paragraphe_RespecteLesReglesDeValidation()
        {
            Paragraphe invalide = new Paragraphe
            {
                Numero = 0,
                Titre = string.Empty,
                Description = string.Empty
            };

            List<ValidationResult> results = Validate(invalide);

            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Paragraphe_ValidePasseLaValidation()
        {
            Paragraphe paragraphe = new Paragraphe
            {
                Id = 7,
                Numero = 1,
                Titre = "Debut",
                Description = "Tu ouvres la porte.",
                MaQuestion = new Question
                {
                    Id = 2,
                    Titre = "Que fais-tu ?",
                    ParagrapheId = 7,
                    MesResponses = new List<Reponse>
                    {
                        new Reponse { Id = 3, Description = "Avancer", QuestionId = 2 }
                    }
                }
            };

            List<ValidationResult> results = Validate(paragraphe);

            Assert.AreEqual(0, results.Count);
            Assert.AreEqual("Debut", paragraphe.Titre);
            Assert.AreEqual("Que fais-tu ?", paragraphe.MaQuestion.Titre);
            Assert.AreEqual("Avancer", paragraphe.MaQuestion.MesResponses.Single().Description);
        }

        [TestMethod]
        public void Modeles_DeDomaine_ConserventLeursValeurs()
        {
            Aventure aventure = new Aventure { Id = 4, Titre = "Le temple" };
            Question question = new Question { Id = 8, Titre = "Entrer ?", ParagrapheId = 4, MesResponses = new List<Reponse>() };
            Reponse reponse = new Reponse { Id = 9, Description = "Oui", QuestionId = 8 };

            Assert.AreEqual(4, aventure.Id);
            Assert.AreEqual("Le temple", aventure.Titre);
            Assert.AreEqual(8, question.Id);
            Assert.AreEqual("Entrer ?", question.Titre);
            Assert.AreEqual(4, question.ParagrapheId);
            Assert.AreEqual(9, reponse.Id);
            Assert.AreEqual("Oui", reponse.Description);
            Assert.AreEqual(8, reponse.QuestionId);
        }

        [TestMethod]
        public void DefaultDesignTimeDbContextFactory_CreeUnContexteSqlServer()
        {
            string originalDirectory = Directory.GetCurrentDirectory();
            string repositoryRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string dataProjectDirectory = Path.Combine(repositoryRoot, "src", "JeuDontOnEstLeHeros.Core.Data");

            try
            {
                Directory.SetCurrentDirectory(dataProjectDirectory);
                DefaultDesignTimeDbContextFactory factory = new DefaultDesignTimeDbContextFactory();

                using DefaultContext context = factory.CreateDbContext(Array.Empty<string>());

                Assert.AreEqual("Microsoft.EntityFrameworkCore.SqlServer", context.Database.ProviderName);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
            }
        }

        private static DefaultContext CreateContext()
        {
            DbContextOptions<DefaultContext> options = new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DefaultContext(options);
        }

        private static List<ValidationResult> Validate(object model)
        {
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            return results;
        }
    }
}
