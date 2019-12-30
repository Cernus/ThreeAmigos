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
    public partial class OrderHistory : System.Web.UI.Page
    {
        private List<Invoice> data;
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
            data = OrderService.GetInvoices();

            InvoiceGridView.DataSource = data;
            InvoiceGridView.DataBind();
        }

        protected void InvoiceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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