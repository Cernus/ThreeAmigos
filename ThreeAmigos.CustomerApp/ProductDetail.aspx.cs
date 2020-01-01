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
                try
                {
                    ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                }
                catch
                {
                    Response.Redirect("~/Default");
                }

                //Redirect to home if have not navigate here through Store Page
                string previousPage = (string)ViewState["RefUrl"];
                string substring = previousPage.Substring(previousPage.LastIndexOf('/') + 1);
                if(substring == "Store")
                {
                    productId = Int32.Parse(Request.QueryString["Id"]);

                    // Redirect to Home page if product does not exist
                    try
                    {
                        PopulatePage();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("~/Default");
                    }
                }
                else
                {
                    Response.Redirect("~/Default");
                }
                
            }

        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            OrderDto orderDto = null;

            // Check that user has a delivery address and telephone number
            if (CurrentUser.HasAddressAndTel())
            {
                // Check if StockLevel > 0
                if (ProductService.InStock(productId))
                {
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
                    orderDto = new OrderDto
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        TimeOrdered = DateTime.Now.Date
                    };

                }

                if (orderDto != null)
                {
                    // Send Order to InvoiceApi
                    OrderService.CreateOrder(orderDto);

                    // Redirect to OrderSuccess

                }
                else
                {
                    Response.Redirect("~/Default");
                }
            }
            else
            {
                // TODO: Display validation message on page
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
            {
                Response.Redirect((string)refUrl);
            }
            else
            {
                Response.Redirect("~/Default");
            }
        }
        private void PopulatePage()
        {
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
                categoryLabel.Text = product.Category;

                // Display Brand
                brandLabel.Text = product.Brand;

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


    }
}