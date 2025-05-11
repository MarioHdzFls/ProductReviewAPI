namespace ProductReviewAPI.Utils
{
    public class ReadabilityHelper
    {
        public static Task<int> CalculateScoreAsync(string content)
        {
            // Simulación de cálculo de puntuación de legibilidad
            return Task.FromResult(CalculateScore(content));
        }

        public static int CalculateScore(string content)
        {
            // Implementación básica de cálculo de puntuación
            return content.Length % 100; // Ejemplo simple basado en la longitud del contenido
        }
    }
}
