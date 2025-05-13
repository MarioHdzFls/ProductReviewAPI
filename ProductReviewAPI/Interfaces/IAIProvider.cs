using ProductReviewAPI.Utils;

namespace ProductReviewAPI.Interfaces
{
    public interface IAIProvider
    {
        Task<string> GetSentimentAsync(string content, SentimentHelper helper);
        Task<double> GetReadabilityScoreAsync(string content);
        Task<List<string>> GetSuggestionsAsync(string content);
        Task<string> GetProviderInfoAsync();
    }
}
