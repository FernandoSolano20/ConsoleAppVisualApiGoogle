using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Res.Visual
{
    public class LocalizedObjectAnnotation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
