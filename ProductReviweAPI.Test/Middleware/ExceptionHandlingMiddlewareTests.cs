using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;

public class ExceptionHandlingMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_ExceptionThrown_ReturnsInternalServerError()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ExceptionHandlingMiddleware>>();
        var middleware = new ExceptionHandlingMiddleware(async (innerHttpContext) =>
        {
            throw new System.Exception("Test exception");
        }, loggerMock.Object);

        var context = new DefaultHttpContext();

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
    }
}
