namespace ProductReviewAPI.Helpers
{
    public class SuggestionHelper
    {
        public static Task<List<string>> GetSuggestionsAsync(string content)
        {
            return Task.FromResult(GetSuggestions(content));
        }
        public static List<string> GetSuggestions(string content)
        {
            var suggestions = new List<string>();
            if(content.Length < 50)
            {
                suggestions.Add("El contenido es demasiado corto. Por favor, proporciona más detalles.");
            }
            if (content.Length > 500)
            {
                suggestions.Add("El contenido es demasiado largo. Por favor, resume tus ideas.");
            }
            if (!content.Contains("por favor", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Considera usar 'por favor' para hacer tu solicitud más cortés.");
            }
            if (!content.EndsWith("."))
            {
                suggestions.Add("Asegúrate de que tu contenido termine con un punto.");
            }
            if (!content.Contains("gracias", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Considera agregar 'gracias' al final de tu mensaje.");
            }
            if (content.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Parece que mencionas un error. Asegúrate de describirlo claramente.");
            }
            if (content.Contains("ayuda", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si necesitas ayuda, asegúrate de proporcionar detalles específicos.");
            }
            if (content.Contains("reclamo", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás haciendo un reclamo, asegúrate de incluir toda la información relevante.");
            }
            if (content.Contains("sugerencia", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás haciendo una sugerencia, asegúrate de que sea clara y concisa.");
            }
            if (content.Contains("opinión", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás dando tu opinión, asegúrate de que esté bien fundamentada.");
            }
            if (content.Contains("revisión", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás escribiendo una revisión, asegúrate de incluir todos los aspectos relevantes.");
            }
            if (content.Contains("recomendación", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás haciendo una recomendación, asegúrate de que sea clara y concisa.");
            }
            if (content.Contains("comentario", StringComparison.OrdinalIgnoreCase))
            {
                suggestions.Add("Si estás dejando un comentario, asegúrate de que sea constructivo.");
            }

            return suggestions;
        }
    }
}
