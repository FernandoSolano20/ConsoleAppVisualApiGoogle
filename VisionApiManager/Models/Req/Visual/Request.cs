using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.Visual
{
    public class Request
    {
        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("features")]
        public IList<Feature> Features { get; set; } = new List<Feature>();
    }
}
