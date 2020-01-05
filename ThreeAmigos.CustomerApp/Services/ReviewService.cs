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
    // TODO: Put in error handling (e.g. != null for all methods in all Service classes)
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

        public static List<Review> GetCustomerReviews()
        {
            int customerId = UserService.GetCustomerId();

            string json = reviewFac.GetCustomerReviews(customerId);

            string customerName = UserService.GetCustomerName();
            List<Product> products = ProductService.GetProductsDefaultStoreApi();
            List<ReviewDto> reviewsDto = JsonConvert.DeserializeObject<List<ReviewDto>>(json);
            List<Review> customerReviews = new List<Review>();

            // TODO: Copy this safe method of creating a list to all other times in solution
            foreach(ReviewDto reviewDto in reviewsDto)
            {
                try
                {
                    customerReviews.Add(new Review
                    {
                        Rating = reviewDto.Rating,
                        Description = reviewDto.Description,
                        ProductName = products.FirstOrDefault(p => p.Id == reviewDto.ProductId).Name,
                        CustomerName = customerName,
                        ProductId = reviewDto.ProductId
                    });
                }
                catch
                {

                }
                
            }

            return customerReviews;
        }

        public static List<Review> GetProductReviews()
        {
            //string json = reviewFac.GetProductReviews(productId);

            //return json;

            string queryString = HttpContext.Current.Request.QueryString["id"];
            int productId = Int32.Parse(queryString);

            string json = reviewFac.GetProductReviews(productId);

            string productName = ProductService.GetProductName(productId);
            //List<Customer> customers = UserService.GetCustomers();
            List<ReviewDto> reviewsDto = JsonConvert.DeserializeObject<List<ReviewDto>>(json);
            List<Review> productReviews = new List<Review>();

            // TODO: Copy this safe method of creating a list to all other times in solution
            foreach (ReviewDto reviewDto in reviewsDto)
            {
                try
                {
                    productReviews.Add(new Review
                    {
                        Rating = reviewDto.Rating,
                        Description = reviewDto.Description,
                        ProductName = productName,
                        CustomerName = "",
                        ProductId = reviewDto.ProductId
                    }) ;
                }
                catch
                {

                }

            }

            return productReviews;
        }

        public static List<int> GetWrittenReviewsIds(int customerId)
        {
            List<int> writtenReviewsProductIds = reviewFac.GetWrittenReviewsIds(customerId);

            return writtenReviewsProductIds;
        }

        public static bool ReviewExists()
        {
            // Get UserId and ProductId
            int userId = UserService.GetUserId();
            string queryString = HttpContext.Current.Request.QueryString["id"];
            int productId = Int32.Parse(queryString);

            // Get all Reviews belonging to this customer
            List<Review> reviews = ReviewService.GetCustomerReviews();

            // Create list of all ProductIds in Reviews by this Customer
            List<int> reviewedProductIds = new List<int>();
            foreach (Review review in reviews)
            {
                reviewedProductIds.Add(review.ProductId);
            }

            // Return true if productId is in reviewedProductIds
            if(reviewedProductIds.Contains(productId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}