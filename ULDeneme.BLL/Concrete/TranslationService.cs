using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ULDeneme.BLL.Abstract;

namespace ULDeneme.BLL.Concrete
{
    public class TranslationService : ITanslatorBLL
    {
        private static readonly string key = "2d0e60389a7c48449a5aba0c9a98d3d0";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
        private static readonly string location = "centralus";

        public TranslationService()
        {
            
        }

        public async Task<string> TranslateText(string textToTranslate, string fromLang, string toLang)
        {
            string route = $"/translate?api-version=3.0&from={fromLang}&to={toLang}";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}
