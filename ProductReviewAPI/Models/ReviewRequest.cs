namespace ProductReviewAPI.Models
{
    /// <summary>
    /// Representa una solicitud para analizar una revisión.
    /// </summary>
    public record ReviewRequest
    {
        /// <summary>
        /// Contenido del texto de la revisión que será analizado.
        /// </summary>
        public string Content { get; init; }

        /// <summary>
        /// Constructor para inicializar una instancia de ReviewRequest.
        /// </summary>
        /// <param name="content">El contenido del texto de la revisión.</param>
        public ReviewRequest(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("El contenido no puede estar vacío.", nameof(content));

            Content = content;
        }
    }
}

