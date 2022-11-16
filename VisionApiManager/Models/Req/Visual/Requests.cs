using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Req.Visual
{
    public class Requests
    {
        [JsonPropertyName("requests")]
        public IList<Request> Request { get; set; }
    }
}
