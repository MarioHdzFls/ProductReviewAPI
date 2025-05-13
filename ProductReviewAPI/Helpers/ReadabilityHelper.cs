namespace ProductReviewAPI.Utils
{
    public class ReadabilityHelper
    {
        public static Task<double> CalculateScoreAsync(string content)
        {
            // Simulación de cálculo de puntuación de legibilidad
            return Task.FromResult(CalculateScore(content));
        }

        public static double CalculateScore(string content)
        {
            // Implementación básica de cálculo de puntuación
            if (string.IsNullOrWhiteSpace(content))
                return 0;
            var words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var sentences = content.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length / (sentences.Length == 0 ? 1 : sentences.Length);
        }
    }
}
