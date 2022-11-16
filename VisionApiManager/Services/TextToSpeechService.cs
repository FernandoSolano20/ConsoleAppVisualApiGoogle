using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VisionApiManager.Models.Req.TextToSpeech;
using VisionApiManager.Models.Res.TextToSpeech;

namespace VisionApiManager.Services
{
    public class TextToSpeechService : ITextToSpeechService
    {
        private readonly string _url =
            "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=";

        private readonly IApiRequest<RequestTextToSpeech, ResponseTextToSpeech> _apiRequest;
        private readonly ILogger<TextToSpeechService> _log;
        private readonly IConfiguration _config;

        public TextToSpeechService(IApiRequest<RequestTextToSpeech, ResponseTextToSpeech> apiRequest, ILogger<TextToSpeechService> log, IConfiguration config)
        {
            _apiRequest = apiRequest;
            _log = log;
            _config = config;
            _url += _config.GetValue<string>("GoogleApiKeysTextToSpeechApi");
        }

        public async Task<ResponseTextToSpeech> GetMp3(string text)
        {
            var request = new RequestTextToSpeech()
            {
                Input = new InputText()
                {
                    Text = text
                },
                Voice = new Voice(),
                AudioConfig = new AudioConfig(),
            };

            try
            {
                return await _apiRequest.GetResult(_url, request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
