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
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
