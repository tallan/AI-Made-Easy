using System;

namespace CognitiveServices.Models.Request_Models
{
    public class ContentModeratorTextQuery : ContentModeratorBaseQuery
    {
        public ContentModeratorTextQuery() {
            this.ContentType = "text/plain";
        }

        public ContentModeratorTextQuery(string subscriptionKey, string endpoint, string contentType) : base(subscriptionKey, endpoint, contentType)
        {
            this.ContentType = "text/plain";
        }

        public string Text { get; set; } = "";

        public bool AutoCorrect { get; set; } = false;

        public bool PII { get; set; } = false;

        public string ListId { get; set; } = String.Empty;

        public bool Classify { get; set; } = false;

        public string Language { get; set; } = String.Empty;

        public string ToQueryString()
        {
            return "?autocorrect=" + AutoCorrect.ToString() + 
                    Helpers.AddParameter("pii", PII) +
                    Helpers.AddParameter("listId", ListId) +
                    Helpers.AddParameter("classify", Classify) +
                    Helpers.AddParameter("language", Language);
        }
    }
}
