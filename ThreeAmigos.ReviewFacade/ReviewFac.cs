using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using ThreeAmigos.ReviewFacade.Models;

namespace ThreeAmigos.ReviewFacade
{
    public class ReviewFac : IReviewFac
    {
        // Create a Review in the Review Service
        public HttpResponseMessage CreateReview(string json)
        {
            var client = Client();

            var uri = "api/review/create";

            ReviewDto reviewDto = JsonConvert.DeserializeObject<ReviewDto>(json);
            HttpResponseMessage response = client.PostAsJsonAsync<ReviewDto>(uri, reviewDto).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
            return response;
        }

        public string GetCustomerReviews(int customerId)
        {
            var reviewList = new List<ReviewDto>();

            var client = Client();

            var uri = "api/ReviewByCustomer?customerId=";

            // Get all reviews by customer Id from Review Service
            HttpResponseMessage response = client.GetAsync(uri + customerId).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }

            reviewList = response.Content.ReadAsAsync<List<ReviewDto>>().Result;
            client.Dispose();
            return JsonConvert.SerializeObject(reviewList);
        }

        public string GetProductReviews(int productId)
        {
            var reviewList = new List<ReviewDto>();

            var client = Client();

            var uri = "api/ReviewByProduct?productId=";

            // Get all reviews by customer Id from Review Service
            HttpResponseMessage response = client.GetAsync(uri + productId).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            reviewList = response.Content.ReadAsAsync<List<ReviewDto>>().Result;
            client.Dispose();
            return JsonConvert.SerializeObject(reviewList);
        }

        public List<int> GetWrittenReviewsIds(int customerId)
        {
            List<int> writtenReviewsProductIds = new List<int>();

            var client = Client();

            var uri = "api/ProductIds?customerId=";

            // Get product Id's of all reviews written by this user
            HttpResponseMessage response = client.GetAsync(uri + customerId).Result;
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            writtenReviewsProductIds = response.Content.ReadAsAsync<List<int>>().Result;
            client.Dispose();
            return writtenReviewsProductIds;
        }

        // Create a client that is used to communicate with Review Service
        private static HttpClient Client()
        {
            //Authenticator = new HttpBasicAuthenticator("user", "password")
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://thamcoreviewservice20191204034645.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }
    }
}
