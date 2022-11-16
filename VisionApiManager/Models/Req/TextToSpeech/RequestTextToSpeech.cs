using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.TextToSpeech
{
    public class RequestTextToSpeech
    {
        [JsonPropertyName("input")]
        public InputText Input { get; set; }

        [JsonPropertyName("voice")]
        public Voice Voice { get; set; }

        [JsonPropertyName("audioConfig")]
        public AudioConfig AudioConfig { get; set; }
    }
}
