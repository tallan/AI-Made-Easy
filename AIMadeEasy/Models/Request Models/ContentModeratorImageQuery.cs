using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class ContentModeratorImageQuery : ContentModeratorBaseQuery
    {
        public ContentModeratorImageQuery()
        {
            this.ContentType = "image/jpeg";
        }
        public ContentModeratorImageQuery(string subscriptionKey, string endpoint, string contentType) : base(subscriptionKey, endpoint, contentType)
        {
            this.ContentType = "image/jpeg";
        }

        public Stream FileStream { get; set; }

        public string ImagePath { get; set; }

        public bool CacheImage { get; set; } = false;

        public string ToQueryString()
        {
            return "?cacheImage=" + CacheImage;
        }
    }
}
