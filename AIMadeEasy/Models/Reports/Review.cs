using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CognitiveServices.Models.Reports
{
    public class Review
    {
        public string ReviewHeadline { get; set; }
        public string ReviewBody { get; set; }
        public int StarRating { get; set; }
        public double Sentiment { get; set; }
        public string Language { get; set; }
        public double LanguageConfidence { get; set; }
        public string KeyPhrases { get; set; }
    }

    public static class ReviewExtensions
    {
        public static Review FormatMessage(this Review review)
        {
            review.ReviewBody = review.ReviewBody.Replace("<br />", "\n");
            review.ReviewBody = HttpUtility.HtmlDecode(review.ReviewBody);
            return review;
        }
    }
}
