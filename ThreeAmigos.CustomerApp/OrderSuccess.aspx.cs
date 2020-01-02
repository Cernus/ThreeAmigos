using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThreeAmigos.CustomerApp
{
    // TODO: Update dummy data for invoices to match the real Product data
    public partial class OrderSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Redirect if not come from ProductDetail page
            // Set label
            if (!Page.IsPostBack)
            {

            }
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {

        }
    }
}