using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.TextToSpeech
{
    public class AudioConfig
    {
        [JsonPropertyName("audioEncoding")]
        public string AudioEncoding { get; set; } = "MP3";
    }
}
