namespace ProductReviewAPI.Models
{
    /// <summary>
    /// Representa la respuesta de una revisión, incluyendo el análisis de sentimiento,
    /// la puntuación de legibilidad y sugerencias para mejorar.
    /// </summary>
    public record ReviewResponse
    {
        /// <summary>
        /// Sentimiento analizado del texto de la revisión (e.g., "Positivo", "Negativo").
        /// </summary>
        public string Sentiment { get; init; }

        /// <summary>
        /// Puntuación de legibilidad del texto (escala de 0 a 100).
        /// </summary>
        public int ReadabilityScore { get; init; }

        /// <summary>
        /// Lista de sugerencias para mejorar el texto de la revisión.
        /// </summary>
        public IReadOnlyList<string> Suggestions { get; init; }

        /// <summary>
        /// Constructor para inicializar una instancia de ReviewResponse.
        /// </summary>
        /// <param name="sentiment">El sentimiento analizado.</param>
        /// <param name="readabilityScore">La puntuación de legibilidad.</param>
        /// <param name="suggestions">Las sugerencias para mejorar.</param>
        public ReviewResponse(string sentiment, int readabilityScore, IReadOnlyList<string> suggestions)
        {
            if (string.IsNullOrWhiteSpace(sentiment))
                throw new ArgumentException("El sentimiento no puede estar vacío.", nameof(sentiment));

            if (readabilityScore < 0 || readabilityScore > 100)
                throw new ArgumentOutOfRangeException(nameof(readabilityScore), "La puntuación debe estar entre 0 y 100.");

            Sentiment = sentiment;
            ReadabilityScore = readabilityScore;
            Suggestions = suggestions ?? throw new ArgumentNullException(nameof(suggestions));
        }
    }
}
