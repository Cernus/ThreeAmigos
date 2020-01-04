using System;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CustomerReviews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Get products from StoreApi
            // TODO: If StoreApi is down then get Products from Customer Api
            
            // Redirect if Customer Id does not exist in database
            Security.RedirectIfInvalidCustomerId();

            PopulatePage();
        }

        private void PopulatePage()
        {
            int customerId = UserService.GetUserId();
            test.Text = ReviewService.GetCustomerReviews(customerId);
        }
    }
}