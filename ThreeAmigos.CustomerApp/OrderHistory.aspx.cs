using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    // TODO: Get Product Information from Product Service, not Dummy Order
    // TODO: Disable Write review link if a review for that product and customer already exist (call Review Service)
    public partial class OrderHistory : Page
    {
        private List<Invoice> data;
        private List<int> writtenReviewsProductIds; //TODO
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
            data = OrderService.GetInvoices();

            InvoiceGridView.DataSource = data;
            InvoiceGridView.DataBind();
        }

        protected void InvoiceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // TODO: Disable write Review for products that this customer has already reviewed
            // Handle if writtenReviewsProductIds is null

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerID = InvoiceGridView.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView ProductOrderGridView = (GridView)e.Row.FindControl("ProductOrderGridView");

                var productOrder = data[0].products;

                ProductOrderGridView.DataSource = productOrder;
                ProductOrderGridView.DataBind();
            }
        }
    }
}