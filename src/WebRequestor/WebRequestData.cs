using Newtonsoft.Json;

namespace WebRequestor
{
    public class WebRequestData
    {
        [JsonProperty(PropertyName = "length", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Length { get; set; }

        [JsonProperty(PropertyName = "sample", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Sample { get; set; }

        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Error { get; set; }
    }
}
