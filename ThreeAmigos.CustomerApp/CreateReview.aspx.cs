using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CreateReview : System.Web.UI.Page
    {
        int productId;
        // TODO: Add validation on the spinner
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Security: Redirect if not logged in
            if (!Page.IsPostBack)
            {
                PopulatePage();
            }
        }

        private void PopulatePage()
        {
            productId = Int32.Parse(Request.QueryString["Id"]);
            string productName = ProductService.GetProductName(productId);
            if (productName != null)
            {
                productNameLabel.Text = "Write review for " + productName + ".";
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ReviewDto reviewDto = new ReviewDto
            {
                Rating = Int32.Parse(ratingSpinner.Value),
                Body = bodyTextBox.Text,
                ProductId = productId,
                CustomerId = CurrentUser.GetCustomerId()
            };

            ReviewService.CreateReview(reviewDto);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}