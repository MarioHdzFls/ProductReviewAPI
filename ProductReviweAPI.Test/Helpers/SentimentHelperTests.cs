using Xunit;
using ProductReviewAPI.Utils;
using System.Collections.Generic;

public class SentimentHelperTests
{
    [Fact]
    public void Classify_PositiveContent_ReturnsPositive()
    {
        // Arrange
        var helper = new SentimentHelper(
            new List<string> { "excelente", "bueno" },
            new List<string> { "malo", "terrible" }
        );
        var content = "Este producto es excelente.";

        // Act
        var result = helper.Classify(content);

        // Assert
        Assert.Equal("positive", result);
    }

    [Fact]
    public void Classify_NegativeContent_ReturnsNegative()
    {
        // Arrange
        var helper = new SentimentHelper(
            new List<string> { "excelente", "bueno" },
            new List<string> { "malo", "terrible" }
        );
        var content = "Este producto es terrible.";

        // Act
        var result = helper.Classify(content);

        // Assert
        Assert.Equal("negative", result);
    }

    [Fact]
    public void Classify_NeutralContent_ReturnsNeutral()
    {
        // Arrange
        var helper = new SentimentHelper(
            new List<string> { "excelente", "bueno" },
            new List<string> { "malo", "terrible" }
        );
        var content = "Este producto es regular.";

        // Act
        var result = helper.Classify(content);

        // Assert
        Assert.Equal("neutral", result);
    }
}
