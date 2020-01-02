using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CustomerReviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulatePage();
        }

        private void PopulatePage()
        {
            int customerId = CurrentUser.GetCustomerId();
            test.Text = ReviewService.GetCustomerReviews(customerId);
        }
    }
}