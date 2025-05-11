using ProductReviewAPI.Models;
namespace ProductReviewAPI.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewResponse> AnalyzeReviewAsync(ReviewRequest request);
    }
}
