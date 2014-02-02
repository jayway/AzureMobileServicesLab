using Newtonsoft.Json;

namespace AzureMobileServicesLab.WP8.Model
{
    public class Answer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public string Choice { get; set; }
    }
}
