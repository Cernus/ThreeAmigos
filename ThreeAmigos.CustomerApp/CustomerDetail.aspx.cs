using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CustomerDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Redirect to Home if user does not have permission to view this page
                Security.RedirectIfNoPermissions();

                PopulatePage();
            }
        }

        // Display Customer Details
        private void PopulatePage()
        {
            // Get object from CustomerApi
            Customer customer = UserService.GetCustomer();

            // Display UserName
            if (customer.Username != null)
            {
                //usernameLabel.Text = customer_old[0].ToString();
                usernameLabel.Text = customer.Username;
            }

            // Display Name
            string firstName = "";
            string secondName = "";

            if (customer.FirstName != null)
            {
                firstName = customer.FirstName;
            }

            if (customer.SecondName != null)
            {
                secondName = customer.SecondName;
            }

            fullnameLabel.Text = firstName + " " + secondName;

            // Display Address
            if (customer.Address != null)
            {
                String[] address = customer.Address.Split(',');
                HtmlGenericControl[] addressLabel = new HtmlGenericControl[address.Length];
                for (int i = 0; i < address.Length; i++)
                {
                    addressLabel[i] = new HtmlGenericControl("label");
                    addressLabel[i].InnerText = address[i];
                    addressLabel[i].Attributes.Add("class", "form-control");
                }

                for (int i = 0; i < addressLabel.Length; i++)
                {
                    addressDiv.Controls.Add(addressLabel[i]);
                }
            }

            // Display Email Address
            if (customer.EmailAddress != null)
            {
                emailAddressLabel.Text = customer.EmailAddress;
            }

            // Display Tel Number
            if (customer.Tel != null)
            {
                telLabel.Text = customer.Tel;

            }

            // Display Can Buy
            try
            {
                if (customer.Sell_To == true)
                {
                    canBuyLabel.Text = "Yes";
                }
                else
                {
                    canBuyLabel.Text = "No";
                }
            }
            catch
            {
                canBuyLabel.Text = "No";
            }

        }
    }
}