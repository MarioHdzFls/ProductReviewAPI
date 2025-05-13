using Xunit;
using ProductReviewAPI.Helpers;
using System.Collections.Generic;

public class SuggestionHelperTests
{
    [Fact]
    public void GetSuggestions_ShortContent_ReturnsSuggestion()
    {
        // Arrange
        var content = "Texto corto";

        // Act
        var suggestions = SuggestionHelper.GetSuggestions(content);

        // Assert
        Assert.Contains("El contenido es demasiado corto. Por favor, proporciona más detalles.", suggestions);
    }

    [Fact]
    public void GetSuggestions_LongContent_ReturnsSuggestion()
    {
        // Arrange
        var content = new string('a', 600);

        // Act
        var suggestions = SuggestionHelper.GetSuggestions(content);

        // Assert
        Assert.Contains("El contenido es demasiado largo. Por favor, resume tus ideas.", suggestions);
    }
}
