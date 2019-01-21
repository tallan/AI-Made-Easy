using CognitiveServices.Models.Request_Models;
using CognitiveServices.Services;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matt Visual Search Part 2
            //CallBingVisualSearchAPI();

            // Matt Custom Search Part 2
            //CallBingCustomSearchWebAPI();

            // Matt Custom Search Part 4
            //CallBingCustomSearchImageAPI();

            // Matt Custom Search Part 6
            //CallBingCustomSearchVideoAPI();

            // Matt Custom Search Part 8
            //CallBingCustomAutosuggestAPI();

            // Matt Text Analytics Part 2
            //CallTextAnalyticsLanguageAPI();

            // Matt Text Analytics Part 4
            //CallTextAnalyticsKeyPhrasesAPI();

            // Matt Text Analytics Part 6
            //CallTextAnalyticsSentimentAPI();

            // Matt Text Analytics Part 8
            //CallTextAnalyticsEntityAPI();

            // Matt Content Moderator Part 2
            //CallContentModeratorAPIText();

            // Matt Content Moderator Part 4
            //CallContentModeratorAPIImage();

            // Matt Content Moderator Part 6
            //CallContentModeratorAPIFaces();

            // Matt Content Moderator Part 8
           // CallContentModeratorAPIOCR();
        }

        // Matt Content Moderator Part 1
        public static void CallContentModeratorAPIText()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a some text to analyze:");
                var message = Console.ReadLine();

                // Create query
                var query = new ContentModeratorTextQuery();
                query.AutoCorrect = true;
                query.Classify = true;
                query.PII = true;
                query.Text = message;
                query.Endpoint = Constants.CONTENT_MODERATOR_TEXT_URL;
                query.SubscriptionKey = Constants.CONTENT_MODERATOR_KEY;

                var result = ContentModeratorService.CallContentModeratorTextAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Content Moderator Part 3
        public static void CallContentModeratorAPIImage()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a file name:");
                var imagePath = Console.ReadLine();

                Console.WriteLine("Please enter a content type: (image/jpeg) is default");
                var contentType = "image/jpeg";
                var line = Console.ReadLine();
                if (!String.IsNullOrEmpty(line))
                    contentType = line;

                if (File.Exists(imagePath))
                {
                    var fileName = new FileInfo(imagePath).Name;
                    Console.WriteLine("Getting image Insights for image: " + fileName);
                    Console.WriteLine();

                    var query = new ContentModeratorImageQuery();
                    query.ImagePath = imagePath;
                    query.ContentType = contentType;
                    query.Endpoint = Constants.CONTENT_MODERATOR_IMAGE_URL;
                    query.SubscriptionKey = Constants.CONTENT_MODERATOR_KEY;

                    var result = ContentModeratorService.CallContentModeratorImageAPI(query).Result;
                    ExportJSON(JsonConvert.SerializeObject(result));
                    Console.WriteLine("\nPress Enter to exit ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid Image Path");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Content Moderator Part 5
        public static void CallContentModeratorAPIFaces()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a file name:");
                var imagePath = Console.ReadLine();

                Console.WriteLine("Please enter a content type: (image/jpeg) is default");
                var contentType = "image/jpeg";
                var line = Console.ReadLine();
                if (!String.IsNullOrEmpty(line))
                    contentType = line;

                if (File.Exists(imagePath))
                {
                    var fileName = new FileInfo(imagePath).Name;
                    Console.WriteLine("Getting image Insights for image: " + fileName);
                    Console.WriteLine();

                    var query = new ContentModeratorImageQuery();
                    query.ImagePath = imagePath;
                    query.ContentType = contentType;
                    query.Endpoint = Constants.CONTENT_MODERATOR_IMAGE_URL;
                    query.SubscriptionKey = Constants.CONTENT_MODERATOR_KEY;

                    var result = ContentModeratorService.CallContentModeratorFacesAPI(query).Result;
                    ExportJSON(JsonConvert.SerializeObject(result));
                    Console.WriteLine("\nPress Enter to exit ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid Image Path");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Content Moderator Part 7
        public static void CallContentModeratorAPIOCR()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a file name:");
                var imagePath = Console.ReadLine();

                Console.WriteLine("Please enter a content type: (image/jpeg) is default");
                var contentType = "image/jpeg";
                var line = Console.ReadLine();
                if (!String.IsNullOrEmpty(line))
                    contentType = line;

                if (File.Exists(imagePath))
                {
                    var fileName = new FileInfo(imagePath).Name;
                    Console.WriteLine("Getting image Insights for image: " + fileName);
                    Console.WriteLine();

                    var query = new ContentModeratorOCRQuery();
                    query.ImagePath = imagePath;
                    query.ContentType = contentType;
                    query.Endpoint = Constants.CONTENT_MODERATOR_IMAGE_URL;
                    query.SubscriptionKey = Constants.CONTENT_MODERATOR_KEY;

                    var result = ContentModeratorService.CallContentModeratorOCRAPI(query).Result;
                    ExportJSON(JsonConvert.SerializeObject(result));
                    Console.WriteLine("\nPress Enter to exit ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid Image Path");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Visual Search Part 1
        public static void CallBingVisualSearchAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a file name:");
                var imagePath = Console.ReadLine();

                // Get the website filter
                Console.WriteLine("Please enter in a website to filter to:");
                var site = Console.ReadLine();

                if (File.Exists(imagePath))
                {
                    var fileName = new FileInfo(imagePath).Name;
                    Console.WriteLine("Getting image Insights for image: " + fileName);
                    var query = new BingVisualSearchQuery(new FileStream(imagePath, FileMode.Open), Constants.BING_VISUAL_SEARCH_KEY, site, "en-US");
                    var result = BingVisualSearchService.CallVisualSearchAPI(query).Result;
                    ExportJSON(JsonConvert.SerializeObject(result));
                    Console.WriteLine("\nPress Enter to exit ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid Image Path");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Custom Search Part 1
        public static void CallBingCustomSearchWebAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a search query:");
                var searchQuery = Console.ReadLine();
                var query = new BingWebSearchQuery(searchQuery, Constants.BING_CUSTOM_SEARCH_KEY, Constants.CUSTOM_CONFIG_ID, "en-US", 10);
                var result = BingWebSearchService.CallWebSearchAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));                
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Custom Search Part 3
        public static void CallBingCustomSearchImageAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a search query:");
                var searchQuery = Console.ReadLine();
                var query = new BingImageSearchQuery(searchQuery, Constants.BING_CUSTOM_SEARCH_KEY, Constants.CUSTOM_CONFIG_ID, "en-US", 10);
                var result = BingImageSearchService.CallImageSearchAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Custom Search Part 5
        public static void CallBingCustomSearchVideoAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a search query:");
                var searchQuery = Console.ReadLine();
                var query = new BingVideoSearchQuery(searchQuery, Constants.BING_CUSTOM_SEARCH_KEY, Constants.CUSTOM_CONFIG_ID, "en-US", 10);
                var result = BingVideoSearchService.CallVideoSearchAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Custom Search Part 7
        public static void CallBingCustomAutosuggestAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a search query:");
                var searchQuery = Console.ReadLine();
                var query = new BingAutosuggestQuery(searchQuery,Constants.AUTOSUGGEST_SUBSCRIPTION_KEY, Constants.AUTOSUGGEST_SUBSCRIPTION_KEY);
                var result = BingAutosuggestService.callAutosuggestSearchAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Text Analytics Part 1
        public static void CallTextAnalyticsLanguageAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a some text to analyze:");
                var message = Console.ReadLine();

                var document = new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = message
                };
                var documentList = new List<Input>();
                documentList.Add(document);
                var query = new TextAnalyticsLanguageQuery(Constants.TEXT_ANALYTICS_URL, Constants.TEXT_ANALYTICS_KEY, documentList.ToArray());
                var result = TextAnalyticsService.callTextAnalyticsDetectLangAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Text Analytics Part 3
        public static void CallTextAnalyticsKeyPhrasesAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a some text to analyze:");
                var message = Console.ReadLine();

                var document = new MultiLanguageInput()
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = "en-US",
                    Text = message
                };
                var documentList = new List<MultiLanguageInput>();
                documentList.Add(document);
                var query = new TextAnalyticsQuery(Constants.TEXT_ANALYTICS_URL, Constants.TEXT_ANALYTICS_KEY, documentList.ToArray());
                var result = TextAnalyticsService.callTextAnalyticsKeyPhrasesAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Text Analytics Part 5
        public static void CallTextAnalyticsSentimentAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a some text to analyze:");
                var message = Console.ReadLine();

                var document = new MultiLanguageInput()
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = "en-US",
                    Text = message
                };
                var documentList = new List<MultiLanguageInput>();
                documentList.Add(document);
                var query = new TextAnalyticsQuery(Constants.TEXT_ANALYTICS_URL, Constants.TEXT_ANALYTICS_KEY, documentList.ToArray());
                var result = TextAnalyticsService.callTextAnalyticsSentimentAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        // Matt Text Analytics Part 7
        public static void CallTextAnalyticsEntityAPI()
        {
            try
            {
                // Get the file name
                Console.WriteLine("Please enter a some text to analyze:");
                var message = Console.ReadLine();

                var document = new MultiLanguageInput()
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = "en-US",
                    Text = message
                };
                var documentList = new List<MultiLanguageInput>();
                documentList.Add(document);
                var query = new TextAnalyticsQuery(Constants.TEXT_ANALYTICS_PREVIEW_URL, Constants.TEXT_ANALYTICS_KEY, documentList.ToArray());
                var result = TextAnalyticsService.callTextAnalyticsEntityAPI(query).Result;
                ExportJSON(JsonConvert.SerializeObject(result));
                Console.WriteLine("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
                throw;
            }
        }

        private static void ExportJSON(string json)
        {
            JObject parsed = JObject.Parse(json);
            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

    }
}
