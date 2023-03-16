using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ULDeneme.BLL.Abstract;
using ULDeneme.ViewModel.VocabularyViewModels;

namespace ULDeneme.UI.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechController : Controller
    {
        private readonly ISpeechBLL _speechBLL;

        public SpeechController(ISpeechBLL speechBLL)
        {
            _speechBLL = speechBLL;
        }

        [HttpPost("synthesize")]
        public async Task<IActionResult> Synthesize([FromBody] SpeechRequest request)
        {
            try
            {
                var audioData = await _speechBLL.TextToSpeechAsync(request.Text, request.Language);
                return File(audioData, "audio/mp3");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public class SpeechRequest
        {
            public string Text { get; set; }
            public string Language { get; set; }
        }

    }
}
