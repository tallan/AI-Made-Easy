using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class ContentModeratorBaseQuery
    {
        public ContentModeratorBaseQuery() {}

        public ContentModeratorBaseQuery(string subscriptionKey, string endpoint, string contentType)
        {
            this.SubscriptionKey = subscriptionKey;
            this.Endpoint = endpoint;
            this.ContentType = contentType;
        }

        public string SubscriptionKey { get; set; } = "";
        public string Endpoint { get; set; } = "";
        public string ContentType { get; set; }
    }
}
