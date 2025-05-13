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

        [HttpPost("GetReview")]
        public async Task<ActionResult<ReviewResponse>> GetReview([FromBody] ReviewRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var response = await _reviewService.AnalyzeReviewAsync(request);
            return Ok(response);
        }
    }
}
