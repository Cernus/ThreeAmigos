using System;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class UpdateCustomer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Redirect to Home if user does not have permission to view this page
                Security.RedirectIfNoPermissions();

                // Send data to User Control
                try
                {
                    customerInputs.CustomerUpdateDto = UserService.GetUserUpdate();
                }
                catch
                {
                    Response.Redirect("~/Default");
                }
            }
        }

        // Update Customer entry in database
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CustomerUpdateDto customerUpdateDto = customerInputs.GetUpdatedCustomer();
            UserService.UpdateUser(customerUpdateDto);
        }
    }
}