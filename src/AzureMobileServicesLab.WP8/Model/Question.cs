using System;
using Newtonsoft.Json;

namespace AzureMobileServicesLab.WP8.Model
{
    public class Question
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Text { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
    }
}
