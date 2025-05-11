using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Models;
using ProductReviewAPI.Utils;

namespace ProductReviewAPI.Services
{
    public class ReviewService : IReviewService
    {
        public async Task<ReviewResponse> AnalyzeReviewAsync(ReviewRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Content))
                throw new ArgumentException("La solicitud no es válida.", nameof(request));

            // Simulación de una operación asíncrona (e.g., llamada a un servicio externo)  
            await Task.Delay(100);

            // Asegurarse de obtener el resultado de la tarea antes de compararlo  
            var readabilityScore = await ReadabilityHelper.CalculateScoreAsync(request.Content);
            var sentiment = readabilityScore > 50 ? "Positive" : "Negative";

            return new ReviewResponse(
                sentiment: sentiment,
                readabilityScore: readabilityScore,
                suggestions: new List<string> { "Consider simplifying your sentences." }
            );
        }
    }
}
