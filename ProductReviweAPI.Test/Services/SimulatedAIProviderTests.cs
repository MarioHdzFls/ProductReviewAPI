using Moq;
using Xunit;
using ProductReviewAPI.Services;
using ProductReviewAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SimulatedAIProviderTests
{
    private readonly SimulatedAIProvider _provider;
    private readonly SentimentHelper _sentimentHelper;

    public SimulatedAIProviderTests()
    {
        _sentimentHelper = new SentimentHelper(
            new List<string> { "excelente", "bueno" },
            new List<string> { "malo", "terrible" }
        );
        _provider = new SimulatedAIProvider(_sentimentHelper);
    }

    [Fact]
    public async Task GetSentimentAsync_ValidContent_ReturnsSentiment()
    {
        // Arrange
        var content = "Este producto es excelente.";

        // Act
        var sentiment = await _provider.GetSentimentAsync(content, _sentimentHelper);

        // Assert
        Assert.Equal("positive", sentiment);
    }

    [Fact]
    public async Task GetReadabilityScoreAsync_ValidContent_ReturnsScore()
    {
        // Arrange
        var content = "Este es un texto de prueba.";

        // Act
        var score = await _provider.GetReadabilityScoreAsync(content);

        // Assert
        Assert.True(score > 0);
    }

    [Fact]
    public async Task GetSuggestionsAsync_ValidContent_ReturnsSuggestions()
    {
        // Arrange
        var content = "Texto corto";

        // Act
        var suggestions = await _provider.GetSuggestionsAsync(content);

        // Assert
        Assert.Contains("El contenido es demasiado corto", suggestions[0]);
    }
}
