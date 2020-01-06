using System;
using System.Web.UI;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class CreateCustomer : Page
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
            UserService.CreateUser(customerUpdateDto);
            Security.Authenticate(customerUpdateDto.Username, customerUpdateDto.Password);
        }
    }
}