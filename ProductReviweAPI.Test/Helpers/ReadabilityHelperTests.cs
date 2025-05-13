using Xunit;
using ProductReviewAPI.Utils;

public class ReadabilityHelperTests
{
    [Fact]
    public void CalculateScore_ValidContent_ReturnsScore()
    {
        // Arrange
        var content = "Este es un texto de prueba. Tiene varias oraciones.";

        // Act
        var score = ReadabilityHelper.CalculateScore(content);

        // Assert
        Assert.True(score > 0);
    }

    [Fact]
    public void CalculateScore_EmptyContent_ReturnsZero()
    {
        // Arrange
        var content = "";

        // Act
        var score = ReadabilityHelper.CalculateScore(content);

        // Assert
        Assert.Equal(0, score);
    }
}
