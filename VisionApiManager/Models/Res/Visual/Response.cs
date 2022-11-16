using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VisionApiManager.Models.Res.Visual
{
    public class Response
    {
        [JsonPropertyName("localizedObjectAnnotations")]
        public IList<LocalizedObjectAnnotation> LocalizedObjectAnnotations { get; set; }
    }
}
