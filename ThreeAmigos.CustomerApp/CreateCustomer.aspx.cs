using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    // TODO: Add validation for creating/updating customer (especially tel number)
    // TODO: Add Back button
    public partial class CreateCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Security.RedirectIfNotGuest();
            }
        }

        // Create a new Customer in the database
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CustomerUpdateDto customerUpdateDto = customerInputs.GetUpdatedCustomer();
            CurrentUser.CreateUser(customerUpdateDto);
        }
    }
}