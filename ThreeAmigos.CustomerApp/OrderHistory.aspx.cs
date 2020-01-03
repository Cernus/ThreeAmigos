using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerApp.Services;
using ThreeAmigos.OrderFacade;

namespace ThreeAmigos.CustomerApp
{
    // TODO: Disable Write review link if a review for that product and customer already exist (call Review Service)
    public partial class OrderHistory : System.Web.UI.Page
    {
        private List<Invoice> data;
        private List<int> writtenReviewsProductIds;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Security - Redirect if user is not logged in
            if (!Page.IsPostBack)
            {
                PopulatePage();
            }
        }

        private void PopulatePage()
        {
            int customerId = CurrentUser.GetCustomerId();
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