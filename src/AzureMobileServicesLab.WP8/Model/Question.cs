using System;

namespace AzureMobileServicesLab.WP8.Model
{
    public class Question
    {
        // TODO: Add Question table to your service
        //[JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Text { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
    }
}
