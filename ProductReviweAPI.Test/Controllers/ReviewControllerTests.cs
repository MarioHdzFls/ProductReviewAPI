using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAPI.Controllers;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Models;
using System.Threading.Tasks;

namespace ProductReviewAPI.Tests.Controllers
{
    public class ReviewControllerTests
    {
        private readonly Mock<IReviewService> _reviewServiceMock;
        private readonly ReviewController _controller;

        public ReviewControllerTests()
        {
            _reviewServiceMock = new Mock<IReviewService>();
            _controller = new ReviewController(_reviewServiceMock.Object);
        }

        [Fact]
        public async Task GetReview_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new ReviewRequest("Este producto es excelente.");
            var expectedResponse = new ReviewResponse("Positivo", 85.0, new List<string> { "Añadir más detalles." });

            _reviewServiceMock
                .Setup(s => s.AnalyzeReviewAsync(It.IsAny<ReviewRequest>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetReview(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ReviewResponse>(okResult.Value);
            Assert.Equal("Positivo", response.Sentiment);
        }

        [Fact]
        public async Task GetReview_NullRequest_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetReview(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }
    }
}
