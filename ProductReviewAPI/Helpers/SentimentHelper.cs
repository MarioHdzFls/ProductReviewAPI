namespace ProductReviewAPI.Utils
{
    public class SentimentHelper
    {
        private readonly List<string> _positiveKeywords;
        private readonly List<string> _negativeKeywords;

        public SentimentHelper(IEnumerable<string> positiveKeywords, IEnumerable<string> negativeKeywords)
        {
            _positiveKeywords = positiveKeywords.ToList();
            _negativeKeywords = negativeKeywords.ToList();
        }
        public static Task<string> ClassifyAsync(string content, SentimentHelper helper)
        {
            // Simulación de clasificación asíncrona
            return Task.FromResult(helper.Classify(content));
        }
        public string Classify(string content)
        {
            if (_positiveKeywords.Any(keyword => content.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                return "positive";

            if (_negativeKeywords.Any(keyword => content.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                return "negative";

            return "neutral";
        }
    }
}
