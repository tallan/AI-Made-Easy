using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveServices.Models.Reports
{
    public static class TextAnalyticsUtil
    {
        public static TextAnalyticsReportContext GenerateSentimentReport(IEnumerable<Review> reviews)
        {
            return new TextAnalyticsReportContext(reviews.OrderBy(x => Guid.NewGuid()).Take(25));
        }
    }

    public class TextAnalyticsReportContext
    {
        public List<ReviewStarGrouping> ReviewScoreGroups { get; set; } = new List<ReviewStarGrouping>();
        public List<KeyPhraseCount> KeyPhraseCounts { get; set; } = new List<KeyPhraseCount>();
        public List<Review> ReviewCollection { get; set; } = new List<Review>();
        public double AverageScore { get; set; }
        public int MinimumScore { get; set; }
        public int MaximumScore { get; set; }

        public TextAnalyticsReportContext(IEnumerable<Review> reviews)
        {
            ReviewScoreGroups = new List<ReviewStarGrouping>
            {
                new ReviewStarGrouping(1),
                new ReviewStarGrouping(2),
                new ReviewStarGrouping(3),
                new ReviewStarGrouping(4),
                new ReviewStarGrouping(5)
            };
            ReviewCollection = reviews.ToList();
            foreach (var review in reviews)
            {
                ReviewScoreGroups.FirstOrDefault(x => x.StarRating == review.StarRating).Reviews.Add(review.FormatMessage());
                KeyPhraseCounts.AppendKeyPhrases(review.KeyPhrases);
            }
            MinimumScore = ReviewCollection.Min(x => x.StarRating);
            MaximumScore = ReviewCollection.Max(x => x.StarRating);
            AverageScore = ReviewCollection.Average(x => x.StarRating);
        }
    }
    public class ReviewStarGrouping
    {
        public int StarRating { get; set; }
        public List<Review> Reviews { get; set; }
        public ReviewStarGrouping(int starRating)
        {
            StarRating = starRating;
            Reviews = new List<Review>();
        }
    }
    public class KeyPhraseCount
    {
        public int Count { get; set; }
        public string KeyPhrase { get; set; }
        public KeyPhraseCount(string keyPhrase)
        {
            Count = 1;
            KeyPhrase = keyPhrase;
        }
    }

    public static class KeyWordCountListExtensions
    {
        public static List<KeyPhraseCount> AppendKeyPhrase(this List<KeyPhraseCount> keyPhraseCounts, string keyPhrase)
        {
            var match = keyPhraseCounts.FirstOrDefault(x => x.KeyPhrase.Equals(keyPhrase, StringComparison.InvariantCultureIgnoreCase));
            if(match != null)
            {
                match.Count = match.Count + 1;
            }
            else if(!string.IsNullOrWhiteSpace(keyPhrase))
            {
                keyPhraseCounts.Add(new KeyPhraseCount(keyPhrase));
            }
            return keyPhraseCounts;
        }
        public static List<KeyPhraseCount> AppendKeyPhrases(this List<KeyPhraseCount> keyPhraseCounts, string keyPhrases)
        {
            var phrases = keyPhrases.Split(", ").Select(x => x.Trim());
            foreach(var phrase in phrases)
            {
                keyPhraseCounts.AppendKeyPhrase(phrase);
            }
            return keyPhraseCounts;
        }
    }
}
