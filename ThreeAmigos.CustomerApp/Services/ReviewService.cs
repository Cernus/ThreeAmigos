using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.ReviewFacade;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class ReviewService
    {
        //private static DummyReview reviewFac = new DummyReview();
        private static ReviewFac reviewFac = new ReviewFac();

        // Create new review
        public static void CreateReview(ReviewDto reviewDto)
        {
            string json = JsonConvert.SerializeObject(reviewDto);
            HttpResponseMessage response = reviewFac.CreateReview(json);
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }
        }

        public static string GetCustomerReviews(int customerId)
        {
            string json = reviewFac.GetCustomerReviews(customerId);

            return json;
        }

        public static string GetProductReviews(int productId)
        {
            string json = reviewFac.GetProductReviews(productId);

            return json;
        }
    }
}