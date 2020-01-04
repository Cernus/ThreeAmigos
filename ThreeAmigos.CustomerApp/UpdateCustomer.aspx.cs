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

        // Dummy data
        private Object[] GetDummyData()
        {
            String username = "John_Doe1";
            String password = "password1";
            String firstName = "John";
            String secondName = "Doe";
            String address = "49 Balsham Road,Harrold,MK43 5XZ";
            String emailAddress = "johndoe@gmail.com";
            String tel = "07015234278";

            Object[] dummy = { username, password, firstName, secondName, address, emailAddress, tel };

            return dummy;
        }
    }
}