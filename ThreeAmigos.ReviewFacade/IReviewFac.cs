using System.Collections.Generic;
using System.Net.Http;

namespace ThreeAmigos.ReviewFacade
{
    public interface IReviewFac
    {
        HttpResponseMessage CreateReview(string json);
        string GetCustomerReviews(int customerId);
        string GetProductReviews(int productId);
        List<int> GetWrittenReviewsIds(int customerId);
    }
}
