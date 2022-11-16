using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.TextToSpeech
{
    public class Voice
    {
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; } = "en-gb";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "en-GB-Standard-A";

        [JsonPropertyName("ssmlGender")]
        public string SsmlGender { get; set; } = "FEMALE";
    }
}
