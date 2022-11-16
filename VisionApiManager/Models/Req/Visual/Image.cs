using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.Visual
{
    public class Image
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
