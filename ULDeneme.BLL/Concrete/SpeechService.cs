using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ULDeneme.BLL.Abstract;

public class SpeechService : ISpeechBLL
{
    private readonly HttpClient _httpClient;

    public SpeechService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> TextToSpeechAsync(string text, string language)
    {
        string hl;
        if (language == "en")
        {
            hl = "en-us";
        }
        else
        {
            hl = language + "-" + language;
        }
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://voicerss-text-to-speech.p.rapidapi.com/?key=d1922879b6cf4d5491bd66319e05077a"),
            Headers =
            {
                { "X-RapidAPI-Key", "303167a597msh605f773cf2cb501p145849jsn1d8ab2f34ca7" },
                { "X-RapidAPI-Host", "voicerss-text-to-speech.p.rapidapi.com" },
            },
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "src", text },
                { "hl", hl},
                { "r", "0" },
                { "c", "mp3" },
                { "f", "uLaw, 44 kHz, Stereo" },
            }),
        };
        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
