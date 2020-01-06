using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class OrderHistory : Page
    {
        private List<Invoice> data;
        private List<Product> products;
        private List<int> writtenReviewsProductIds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Redirect to Home if user does not have permission to view this page
                Security.RedirectIfNoPermissions();

                PopulatePage();
            }
        }

        private void PopulatePage()
        {
            int customerId = UserService.GetCustomerId();
            writtenReviewsProductIds = ReviewService.GetWrittenReviewsIds(customerId);

            // Get List of all Products from Store Api or Customer Api
            products = ProductService.GetProductsDefaultStoreApi();

            // Get Orders from Invoice Service and Add Product Information to Invoices
            data = OrderService.GetInvoices(products);

            InvoiceGridView.DataSource = data;
            InvoiceGridView.DataBind();
        }

        protected void InvoiceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int orderId = Int32.Parse((InvoiceGridView.DataKeys[e.Row.RowIndex]["OrderId"]).ToString());

                GridView ProductOrderGridView = (GridView)e.Row.FindControl("ProductOrderGridView");

                var productOrder = data[orderId].Products;

                ProductOrderGridView.DataSource = productOrder;

                ProductOrderGridView.DataBind();
            }
        }

        protected void ProductOrderGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // TODO: Handle if writtenReviewsProductIds is null

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get Product Id of each row
                object rowView = e.Row.DataItem;
                PropertyInfo pi = rowView.GetType().GetProperty("ProductId");
                int productId = (int)(pi.GetValue(rowView, null));

                if (writtenReviewsProductIds.Contains(productId))
                {
                    e.Row.Cells[6].Enabled = false;
                    e.Row.Cells[6].Text = "Review Submitted";
                }
            }
        }
    }
}