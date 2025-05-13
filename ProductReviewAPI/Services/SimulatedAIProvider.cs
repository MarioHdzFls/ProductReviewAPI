using ProductReviewAPI.Helpers;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Utils;

namespace ProductReviewAPI.Services
{
    public class SimulatedAIProvider : IAIProvider
    {
        private readonly SentimentHelper _sentimentHelper;

        public SimulatedAIProvider(SentimentHelper sentimentHelper)
        {
            _sentimentHelper = sentimentHelper;
        }

        public Task<string> GetSentimentAsync(string content, SentimentHelper helper)
        {
            return SentimentHelper.ClassifyAsync(content, _sentimentHelper);
        }

        public Task<double> GetReadabilityScoreAsync(string content)
        {
            // Fix: Await the result of CalculateScoreAsync and return it as a Task.  
            return ReadabilityHelper.CalculateScoreAsync(content);
        }

        public Task<List<string>> GetSuggestionsAsync(string content)
        {
            return SuggestionHelper.GetSuggestionsAsync(content);
        }

        public Task<string> GetProviderInfoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
