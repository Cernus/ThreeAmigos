using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CustomerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Show if user is admin
            // Show if user is current user
            // note don't need to consider if user is active or inactive

            //string currentUserId = Membership.GetUser().ProviderUserKey.ToString();

            //if(!Context.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default");
            //}

            // TODO: This gets Id of current user
            var test = Context.User.Identity.Name;


            if (!Page.IsPostBack)
            {
                // Redirect to Home if non-admin user is not logged in or trying to view another customer
                Security.RedirectIfNotUsersPage();
                PopulatePage();
            }
        }

        // Display Customer Details
        private void PopulatePage()
        {
            // Get object from CustomerApi
            Customer customer = CurrentUser.GetUser();

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