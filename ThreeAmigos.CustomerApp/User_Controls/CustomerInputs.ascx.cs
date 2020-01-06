using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp;

namespace CustomerApp.User_Controls
{
    public partial class CustomerInputs : UserControl
    {
        public CustomerUpdateDto CustomerUpdateDto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                if (CustomerUpdateDto.Username != null)
                {
                    usernameTextBox.Text = CustomerUpdateDto.Username;
                }

                // Password
                if (CustomerUpdateDto.Password != null)
                {
                    passwordTextBox.Text = CustomerUpdateDto.Password;
                }

                // First Name
                if (CustomerUpdateDto.FirstName != null)
                {
                    firstNameTextBox.Text = CustomerUpdateDto.FirstName;
                }

                // Second Name
                if (CustomerUpdateDto.SecondName != null)
                {
                    secondNameTextBox.Text = CustomerUpdateDto.SecondName;
                }

                // Address
                if (CustomerUpdateDto.Address != null)
                {
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
                }

                // Email Address
                if (CustomerUpdateDto.EmailAddress != null)
                {
                    emailAddressTextBox.Text = CustomerUpdateDto.EmailAddress;
                }

                // Tel Number
                if (CustomerUpdateDto.Tel != null)
                {
                    telTextBox.Text = CustomerUpdateDto.Tel;
                }
            }
        }

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