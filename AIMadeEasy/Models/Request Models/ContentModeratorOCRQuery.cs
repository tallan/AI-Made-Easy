using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class ContentModeratorOCRQuery : ContentModeratorImageQuery
    {
        public ContentModeratorOCRQuery()
        {
            this.Language = "en-US";
        }

        public string Language { get; set; }

        public Boolean Enhanced { get; set; }

        public new string ToQueryString()
        {
            return base.ToQueryString() +
                Helpers.AddParameter("language", Language) +
                Helpers.AddParameter("enhanced", Enhanced.ToString());
        }
    }
}
