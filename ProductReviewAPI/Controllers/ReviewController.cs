using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Models;

namespace ProductReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<ReviewResponse>> Analyze([FromBody] ReviewRequest request)
        {
            try
            {
                var result = await _reviewService.AnalyzeReviewAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (puedes usar un logger aquí)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }
    }
}
