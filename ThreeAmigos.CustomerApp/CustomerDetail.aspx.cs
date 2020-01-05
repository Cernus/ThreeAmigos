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
            fullnameLabel.Text = customer.FirstName + " " + customer.SecondName;

            // Display Address
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

            // Display Email Address
            emailAddressLabel.Text = customer.EmailAddress;

            // Display Tel Number
            telLabel.Text = customer.Tel;

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

        // TODO: Delete
        // Dummy data
        private Object[] GetDummyData()
        {
            String username = "John_Doe1";
            String firstName = "John";
            String secondName = "Doe";
            String address = "49 Balsham Road,Harrold,MK43 5XZ";
            String emailAddresss = "johndoe@gmail.com";
            String tel = "07015234278";
            Boolean sell_to = true;

            Object[] dummy = { username, firstName, secondName, address, emailAddresss, tel, sell_to };

            return dummy;
        }

    }
}