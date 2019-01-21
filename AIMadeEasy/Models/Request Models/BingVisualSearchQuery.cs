using System.IO;

namespace CognitiveServices.Models.Request_Models
{
    public class BingVisualSearchQuery
    {
        public BingVisualSearchQuery(Stream fileStream, string searchKey, string site, string market)
        {
            FileStream = fileStream;
            SearchKey = searchKey;
            Site = site;
            Mkt = market;
        }
        public BingVisualSearchQuery()
        {

        }
        public string SearchKey { get; set; }
        public Stream FileStream { get; set; }
        public string Site { get; set; }
        public string Mkt { get; set; } = "en-US";
        public string SafeSearch { get; set; } = "Off";
        public string SetLang { get; set; } = "";
        public string ImagePath { get; set; }
    }
}
