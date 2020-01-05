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

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            OrderDto orderDto = null;

            // Check that user has a delivery address and telephone number
            if (UserService.HasAddressAndTel())
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

                // Check if StockLevel >= quantity
                if (ProductService.InStock(productId, quantity))
                {
                    ProductService.DecrementStock(productId, quantity);

                    // Create Model
                    orderDto = new OrderDto
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        TimeOrdered = DateTime.Now.Date
                    };

                    if (orderDto != null)
                    {
                        // Send Order to InvoiceApi
                        OrderService.CreateOrder(orderDto);

                        // Redirect to OrderSuccess

                    }
                    else
                    {
                        // TODO: Display to user that item is currently out of stock
                        Response.Redirect("~/Default");
                    }
                }
                else
                {
                    // TODO: Finish coding what happens when order is successful/unsuccessful
                }


            }
            else
            {
                // TODO: Display validation message on page
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Security.RedirectToPreviousPage();
        }
    }
}