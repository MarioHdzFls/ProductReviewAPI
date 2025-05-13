using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using ProductReviewAPI.Services;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Models;
using ProductReviewAPI.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductReviewAPI.Tests.Services
{
    public class ReviewServiceTests
    {
        private readonly Mock<IAIProvider> _aiProviderMock;
        private readonly Mock<ILogger<ReviewService>> _loggerMock;
        private readonly ReviewService _reviewService;

        public ReviewServiceTests()
        {
            _aiProviderMock = new Mock<IAIProvider>();
            _loggerMock = new Mock<ILogger<ReviewService>>();
            _reviewService = new ReviewService(_aiProviderMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task AnalyzeReviewAsync_ValidRequest_ReturnsExpectedResponse()
        {
            // Arrange
            var request = new ReviewRequest("Este producto es excelente.");
            var expectedSentiment = "Positivo";
            var expectedReadability = 85.0;
            var expectedSuggestions = new List<string> { "Añadir más detalles." };

            _aiProviderMock
                .Setup(p => p.GetSentimentAsync(It.IsAny<string>(), It.IsAny<SentimentHelper>()))
                .ReturnsAsync(expectedSentiment);

            _aiProviderMock
                .Setup(p => p.GetReadabilityScoreAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedReadability);

            _aiProviderMock
                .Setup(p => p.GetSuggestionsAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedSuggestions);

            // Act
            var response = await _reviewService.AnalyzeReviewAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(expectedSentiment, response.Sentiment);
            Assert.Equal(expectedReadability, response.ReadabilityScore);
            Assert.Equal(expectedSuggestions, response.Suggestions);
        }

        [Fact]
        public async Task AnalyzeReviewAsync_NullRequest_ThrowsArgumentException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _reviewService.AnalyzeReviewAsync(null));
        }

        [Fact]
        public async Task AnalyzeReviewAsync_ProviderThrowsException_LogsErrorAndThrowsApplicationException()
        {
            // Arrange
            var request = new ReviewRequest("Texto de prueba.");
            _aiProviderMock
                .Setup(p => p.GetSentimentAsync(It.IsAny<string>(), It.IsAny<SentimentHelper>()))
                .ThrowsAsync(new Exception("Error del proveedor."));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApplicationException>(() => _reviewService.AnalyzeReviewAsync(request));
            Assert.Equal("Error al analizar la revisión.", exception.Message);
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }
    }
}
