using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class BingAutosuggestQuery
    {
        public BingAutosuggestQuery(string query, string searchKey, string config)
        {
            this.Query = query;
            this.SearchKey = searchKey;
            this.CustomConfig = config;
        }

        public string SearchKey { get; set; }
        public string CustomConfig { get; set; } = "";
        public string Query { get; set; } = "";

        public string ToQueryString()
        {
            return "q=" + Query + Helpers.AddParameter("customConfig", CustomConfig);
        }
    }
}
