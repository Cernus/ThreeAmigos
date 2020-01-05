using System;
using System.Collections.Generic;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CustomerReviews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.RedirectIfInvalidCustomerId();

            PopulatePage();
        }

        private void PopulatePage()
        {
            // TODO: Display alternate message if there are no reviews in the list

            List<Review> reviews = ReviewService.GetCustomerReviews();

            ProductReviewLabel.Text = reviews[0].CustomerName + "'s Reviews";
            ReviewGridView.DataSource = reviews;
            ReviewGridView.DataBind();
        }
    }
}