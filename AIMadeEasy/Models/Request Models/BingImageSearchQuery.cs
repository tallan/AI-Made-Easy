using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class BingImageSearchQuery : BingSearchBaseQuery
    {
        public BingImageSearchQuery(string query, string key, string config, string market, short count) : base(query, key, config, market, count) { }
        public string Aspect { get; set; }
        public string Color { get; set; }
        public short? Height { get; set; }
        public string ImageContent { get; set; }
        public string ImageType { get; set; }
        public string License { get; set; }
        public int? MaxFileSize { get; set; }
        public int? MaxHeight { get; set; }
        public int? MaxWidth { get; set; }
        public int? MinFileSize { get; set; }
        public int? MinHeight { get; set; }
        public int? MinWidth { get; set; }
        public string Size { get; set; }
        public short? Width { get; set; }

        public new string ToQueryString()
        {
            return base.ToQueryString() +
                Helpers.AddParameter("aspect", Aspect) +
                Helpers.AddParameter("color", Color) +
                Helpers.AddParameter("height", Height) +
                Helpers.AddParameter("imageContent", ImageContent) +
                Helpers.AddParameter("imageType", ImageType) +
                Helpers.AddParameter("license", License) +
                Helpers.AddParameter("maxFileSize", MaxFileSize) +
                Helpers.AddParameter("maxHeight", MaxHeight) +
                Helpers.AddParameter("maxWidth", MaxWidth) +
                Helpers.AddParameter("minFileSize", MinFileSize) +
                Helpers.AddParameter("minHeight", MinHeight) +
                Helpers.AddParameter("minWidth", MinWidth) +
                Helpers.AddParameter("size", Size) +
                Helpers.AddParameter("width", Width);
        }
    }
}
