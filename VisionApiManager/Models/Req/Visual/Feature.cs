using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.Visual
{
    public class Feature
    {
        [JsonPropertyName("maxResults")]
        public int MaxResults { get; set; } = 1;

        [JsonPropertyName("type")]
        public string Type { get; set; } = "OBJECT_LOCALIZATION";
    }
}
