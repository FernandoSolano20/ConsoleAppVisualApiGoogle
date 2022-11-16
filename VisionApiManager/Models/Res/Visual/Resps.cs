using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Res.Visual
{
    public class Resps
    {
        [JsonPropertyName("responses")]
        public IList<Response> Responses { get; set; }
    }
}
