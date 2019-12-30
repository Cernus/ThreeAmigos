using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace CustomerApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetLinkUrls();
        }

        private void SetLinkUrls()
        {
            CustomerDetailLink.HRef = "CustomerDetail?Id=" + CurrentUser.GetCustomerId();
            UpdateCustomerLink.HRef = "UpdateCustomer?id=" + CurrentUser.GetCustomerId();
        }
    }
}