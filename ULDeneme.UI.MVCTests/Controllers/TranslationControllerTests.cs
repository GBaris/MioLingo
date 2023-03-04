using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ULDeneme.BLL.Concrete;
using ULDeneme.UI.MVC.Controllers;
using static ULDeneme.UI.MVC.Controllers.TranslationController;

namespace ULDeneme.UI.MVCTests.Controllers
{
    [TestClass]
    public class TranslationControllerTests
    {

        [TestMethod]
        public async Task Test_TranslateMethod_ReturnsCorrectResult()
        {
            // Arrange
            var translatorService = new TranslationService();
            var controller = new TranslationController(translatorService);
            var expected = "araba";
            var textToTranslate = "car";
            var fromLang = "en";
            var toLang = "tr";

            // Act
            var result = await controller.Translate(textToTranslate, fromLang, toLang);
            var translations = JsonConvert.DeserializeObject<List<TranslationResponse>>(result);
            var actual = translations[0].Translations[0].Text;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}