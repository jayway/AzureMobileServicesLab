namespace AzureMobileServicesLab.WP8.Model
{
    public class Answer
    {
        // TODO: Add Answer table to your service
        //[JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public string Choice { get; set; }
    }
}
