using System;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CreateReview : Page
    {
        // TODO: Add validation on the spinner
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Redirect to Home if Product with id in query string does not exist in database
                Security.RedirectIfInvalidProductId();

                // Redirect to Home if this User has already submitted a Review for this Product
                Security.RedirectIfReviewExists();

                // TODO: Redirect to home if this User has not got an invoice containing this ProductId

                PopulatePage();
            }
        }

        private void PopulatePage()
        {
            int productId = Int32.Parse(Request.QueryString["Id"]);
            string productName = ProductService.GetProductName(productId);
            if (productName != null)
            {
                productNameLabel.Text = "Write review for " + productName + ".";
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.QueryString["Id"]);

            ReviewDto reviewDto = new ReviewDto
            {
                Rating = Int32.Parse(ratingSpinner.Value),
                Description = bodyTextBox.Text,
                ProductId = productId,
                CustomerId = UserService.GetUserId()
            };

            ReviewService.CreateReview(reviewDto);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Security.RedirectToPreviousPage();
        }
    }
}