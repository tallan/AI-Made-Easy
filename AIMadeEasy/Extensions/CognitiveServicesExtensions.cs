using CognitiveServices.Models.Request_Models;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Linq;

namespace CognitiveServices.Extensions
{
    public static class CognitiveServicesExtensions
    {
        public static Input ConvertToRegularInput(this MultiLanguageInput multiLanguageInput)
        {
            return new Input {
                Id = multiLanguageInput.Id,
                Text = multiLanguageInput.Text
            };
        }

        public static TextAnalyticsLanguageQuery ToTextAnalyticsLanguageQuery(this TextAnalyticsQuery query)
        {
            return new TextAnalyticsLanguageQuery
            {
                TextAnalyticsKey = query.TextAnalyticsKey,
                TextAnalyticsEndpoint = query.TextAnalyticsEndpoint,
                Documents = query.Documents.Select(x => x.ConvertToRegularInput()).ToArray()
            };
        }

        public static TextAnalyticsQuery SetLanguage(this TextAnalyticsQuery query, string lang)
        {
            foreach(var doc in query.Documents)
            {
                doc.Language = lang;
            }
            return query;
        }

        public static MultiLanguageInput ToMultiLanguageInput(this string query, string language = "")
        {
            return new MultiLanguageInput {
                Id = Guid.NewGuid().ToString(),
                Language = language,
                Text = query
            };
        }
    }
}
