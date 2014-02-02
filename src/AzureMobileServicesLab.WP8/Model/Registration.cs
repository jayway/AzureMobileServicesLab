using Newtonsoft.Json;

namespace AzureMobileServicesLab.WP8.Model
{
    public class Registration
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "handle")]
        public string Handle { get; set; }
    }
}
