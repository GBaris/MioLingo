using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ULDeneme.BLL.Concrete;

namespace ULDeneme.UI.MVC.Controllers
{
    public class TranslationController : Controller
    {
        private readonly TranslatorService _translatorService;
        public class TranslationResponse
        {
            public List<Translation> Translations { get; set; }
        }

        public class Translation
        {
            public string Text { get; set; }
            public string To { get; set; }
        }
        public TranslationController(TranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        [HttpPost]
        public async Task<string> Translate(string textToTranslate, string fromLang, string toLang)
        {
            var result = await _translatorService.TranslateText(textToTranslate, fromLang, toLang);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Suggest(string word, string fromLang, string toLang)
        {
            var result = await _translatorService.TranslateText(word, fromLang, toLang);
            var suggestions = JsonConvert.DeserializeObject<List<TranslationResponse>>(result);
            var suggestedWords = suggestions.SelectMany(t => t.Translations.Select(tr => tr.Text)).ToList();
            return Json(suggestedWords);
        }
    }
}
