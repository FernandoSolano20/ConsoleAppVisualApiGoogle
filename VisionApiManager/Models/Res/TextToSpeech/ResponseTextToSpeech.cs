using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Res.TextToSpeech
{
    public class ResponseTextToSpeech
    {
        [JsonPropertyName("audioContent")]
        public string AudioContent { get; set; }
    }
}
