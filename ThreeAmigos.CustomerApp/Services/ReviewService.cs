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

        public static List<Review> GetCustomerReviews()
        {
            int customerId = UserService.GetUserId();

            string json = reviewFac.GetCustomerReviews(customerId);
            List<ReviewDto> reviewsDto = JsonConvert.DeserializeObject<List<ReviewDto>>(json);

            if(reviewsDto.Count > 0)
            {
                string customerName = UserService.GetUserName();
                List<Product> products = ProductService.GetProductsDefaultStoreApi();
                List<Review> customerReviews = new List<Review>();

                foreach (ReviewDto reviewDto in reviewsDto)
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
            else
            {
                return null;
            }
        }

        public static List<Review> GetProductReviews()
        {
            //string json = reviewFac.GetProductReviews(productId);

            //return json;

            string queryString = HttpContext.Current.Request.QueryString["id"];
            int productId = Int32.Parse(queryString);

            string json = reviewFac.GetProductReviews(productId);

            string productName = ProductService.GetProductName(productId);
            List<CustomerName> customerNames = UserService.GetCustomerNames();
            List<ReviewDto> reviewsDto = JsonConvert.DeserializeObject<List<ReviewDto>>(json);
            List<Review> productReviews = new List<Review>();

            foreach (ReviewDto reviewDto in reviewsDto)
            {
                try
                {
                    productReviews.Add(new Review
                    {
                        Rating = reviewDto.Rating,
                        Description = reviewDto.Description,
                        ProductName = productName,
                        CustomerName = customerNames.FirstOrDefault(c => c.CustomerId == reviewDto.CustomerId).FullName,
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

            try
            {
                // Create list of all ProductIds in Reviews by this Customer
                List<int> reviewedProductIds = new List<int>();
                foreach (Review review in reviews)
                {
                    reviewedProductIds.Add(review.ProductId);
                }

                // Return true if productId is in reviewedProductIds
                if (reviewedProductIds.Contains(productId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}