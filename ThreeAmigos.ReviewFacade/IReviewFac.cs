using System.Net.Http;

namespace ThreeAmigos.ReviewFacade
{
    public interface IReviewFac
    {
        HttpResponseMessage CreateReview(string json);
    }
}
