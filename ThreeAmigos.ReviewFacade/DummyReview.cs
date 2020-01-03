using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.ReviewFacade
{
    public class DummyReview : IReviewFac
    {
        public HttpResponseMessage CreateReview(string json)
        {
            throw new NotImplementedException();
        }

        public string GetCustomerReviews(int customerId)
        {
            throw new NotImplementedException();
        }

        public string GetProductReviews(int productId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetWrittenReviewsIds(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
