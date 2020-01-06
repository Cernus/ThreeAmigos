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
    public partial class ProductDetail : System.Web.UI.Page
    {
        private int productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Security.RedirectIfInvalidProductId();

                // Redirect to Home page if product does not exist
                PopulatePage();
                ShowReviews();
                HideButton();
            }
        }

        private void PopulatePage()
        {
            productId = Int32.Parse(Request.QueryString["Id"]);

            // Get product
            Product product = ProductService.GetProduct(productId);

            if (product != null)
            {
                // Display Name
                if (product.Name != null)
                {
                    nameLabel.Text = product.Name;
                }

                // Display Category
                categoryLabel.Text = product.CategoryName;

                // Display Brand
                brandLabel.Text = product.BrandName;

                // Display Description
                descriptionLabel.Text = product.Description;

                // Display Price
                priceLabel.Text = product.Price.ToString();

                // Display StockLevel
                stockLevelLabel.Text = product.StockLevel.ToString();
            }
            else
            {
                throw new NullReferenceException("Product not found");
            }

            List<Review> reviews = ReviewService.GetProductReviews();

            if (reviews.Count > 0)
            {
                ReviewGridView.DataSource = reviews;
                ReviewGridView.DataBind();
            }
            else
            {
                // TODO: Handle case for no Reviews
            }
        }

        private void ShowReviews()
        {
            try
            {
                List<Review> reviews = ReviewService.GetProductReviews();
                //test.Text = ReviewService.GetProductReviews().ToString();
            }
            catch
            {
                // Handle not getting Reviews
            }
        }

        private void HideButton()
        {
            if (!Security.IsLoggedIn())
            {
                OrderButton.Visible = false;
            }
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            // Order Created through validation events if they all pass

            Response.Redirect("~/Default");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Security.RedirectToPreviousPage();
        }

        protected void OrderFailedValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            productId = Int32.Parse(Request.QueryString["Id"]);

            // Get quantity
            int quantity;
            try
            {
                quantity = Int32.Parse(quantitySpinner.Value);
            }
            catch
            {
                quantity = 1;
            }

            // Create Model
            OrderDto orderDto = new OrderDto
            {
                ProductId = productId,
                Quantity = quantity,
                TimeOrdered = DateTime.Now.Date
            };

            try
            {
                OrderService.CreateOrder(orderDto);
                args.IsValid = true;

            }
            catch
            {
                args.IsValid = false;

            }
        }

        protected void StockValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            productId = Int32.Parse(Request.QueryString["Id"]);

            // Get quantity
            int quantity;
            try
            {
                quantity = Int32.Parse(quantitySpinner.Value);
            }
            catch
            {
                quantity = 1;
            }

            if (ProductService.InStock(productId, quantity))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void DeliveryValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (UserService.HasDeliveryDetails())
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}