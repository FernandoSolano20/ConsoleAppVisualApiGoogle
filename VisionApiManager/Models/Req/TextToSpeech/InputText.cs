using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.TextToSpeech
{
    public class InputText
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
