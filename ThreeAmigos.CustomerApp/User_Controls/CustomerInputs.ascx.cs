using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp;
using ThreeAmigos.CustomerApp.Services;

namespace CustomerApp.User_Controls
{
    public partial class CustomerInputs : System.Web.UI.UserControl
    {
        public CustomerUpdateDto CustomerUpdateDto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Redirect to Home if user is not logged in or trying to view another customer
            if(!Page.IsPostBack)
            {
                PopulatePage();
            }
        }

        // Display Customer Details
        private void PopulatePage()
        {
            // Populate textboxes if array is not empty
            if (CustomerUpdateDto != null)
            {
                // Username
                usernameTextBox.Text = CustomerUpdateDto.Username;

                // Password
                passwordTextBox.Text = CustomerUpdateDto.Password;
                
                // First Name
                firstNameTextBox.Text = CustomerUpdateDto.FirstName;

                // Second Name
                secondNameTextBox.Text = CustomerUpdateDto.SecondName;

                // Address
                string[] address = CustomerUpdateDto.Address.Split(',');
                TextBox[] addressTextBox = new TextBox[] { address0TextBox, address1TextBox, address2TextBox, address3TextBox, address4TextBox };

                for (int i = 0; i < address.Length; i++)
                {
                    if (i == address.Length - 1)
                    {
                        addressTextBox[addressTextBox.Length - 1].Text = address[i];
                    }
                    else
                    {
                        addressTextBox[i].Text = address[i];
                    }
                }

                // Email Address
                emailAddressTextBox.Text = CustomerUpdateDto.EmailAddress;

                // Tel Number
                telTextBox.Text = CustomerUpdateDto.Tel;
            }
        }

        // TODO: Implement Facade pattern
        public CustomerUpdateDto GetUpdatedCustomer()
        {
            // Add all address labels into one variable
            string customerAddress = null;
            TextBox[] addressTextBox = new TextBox[] { address0TextBox, address1TextBox, address2TextBox, address3TextBox, address4TextBox };
            for (int i = 0; i < addressTextBox.Length; i++)
            {
                if (addressTextBox[i].Text != "")
                {
                    if (customerAddress != null)
                    {
                        customerAddress += ",";
                    }
                    customerAddress += addressTextBox[i].Text.ToString();
                }
            }

            return new CustomerUpdateDto
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text,
                FirstName = firstNameTextBox.Text,
                SecondName = secondNameTextBox.Text,
                Address = customerAddress,
                EmailAddress = emailAddressTextBox.Text,
                Tel = telTextBox.Text,
            };
        }
    }
}