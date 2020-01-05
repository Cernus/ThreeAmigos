using System;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Services;

namespace CustomerApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                SetLinkUrls();
                HideMenuButtons();
                Security.MemoriseCurrentPage(GetCurrentPage());
            }
        }
        protected void SignOutLink_Click(object sender, EventArgs e)
        {
            Security.SignOut();
        }

        private void SetLinkUrls()
        {
            int customerId = UserService.GetUserId();
            
            CustomerDetailLink.HRef = "CustomerDetail?Id=" + customerId;
            UpdateCustomerLink.HRef = "UpdateCustomer?id=" + customerId;
            CustomerReviewsLink.HRef = "CustomerReviews?id=" + customerId;
            StoreLink.HRef = "OrderHistory?id=" + customerId;
        }

        private void HideMenuButtons()
        {
            bool isLoggedIn = Security.IsLoggedIn();
            bool isAdmin = Security.IsAdmin();

            if(!isAdmin)
            {
                if(isLoggedIn)
                {
                    // Hide buttons for Customer
                    SignInLi.Visible = false;
                    CreateCustomerLi.Visible = false;
                }
                else
                {
                    // Hide buttons for Guest
                    SignOutLi.Visible = false;
                    CustomerRUDLi.Visible = false;
                    CustomerReviewsLi.Visible = false;
                    OrderHistoryLi.Visible = false;
                }
            }
        }

        private string GetCurrentPage()
        {
            try
            {
                return "~" + Request.UrlReferrer.AbsolutePath;
            }
            catch
            {
                return "Default";
            }
        }
    }
}