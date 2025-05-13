using Microsoft.Extensions.Logging;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Models;
using ProductReviewAPI.Utils;

namespace ProductReviewAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IAIProvider _aiProvider;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IAIProvider aIProvider, ILogger<ReviewService> logger)
        {
            _aiProvider = aIProvider ?? throw new ArgumentNullException(nameof(aIProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ReviewResponse> AnalyzeReviewAsync(ReviewRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Content))
                throw new ArgumentException("La solicitud no es válida. El contenido no puede estar vacío.", nameof(request));

            _logger.LogInformation("Iniciando análisis de revisión.");

            try
            {
                var provider = _aiProvider;

                // Provide the required arguments for SentimentHelper constructor
                var positiveKeywords = new List<string> { "excelente", "bueno", "positivo", "maravilloso" };
                var negativeKeywords = new List<string> { "malo", "terrible", "negativo", "horrible" };
                var sentimentHelper = new SentimentHelper(positiveKeywords, negativeKeywords);

                var sentiment = await provider.GetSentimentAsync(request.Content, sentimentHelper);
                var readability = await provider.GetReadabilityScoreAsync(request.Content);
                var suggestions = await provider.GetSuggestionsAsync(request.Content);

                _logger.LogInformation("Análisis completado exitosamente.");
                return new ReviewResponse(sentiment, readability, suggestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al analizar la revisión.");
                throw new ApplicationException("Error al analizar la revisión.", ex);
            }
        }
    }
}
