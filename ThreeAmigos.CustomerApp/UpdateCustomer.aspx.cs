using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class UpdateCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Security.RedirectIfNotUsersPage();
                // Send data to User Control
                customerInputs.CustomerUpdateDto = CurrentUser.GetUserUpdate();
            }
        }

        // Update Customer entry in database
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CustomerUpdateDto customerUpdateDto = customerInputs.GetUpdatedCustomer();
            CurrentUser.UpdateUser(customerUpdateDto);
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