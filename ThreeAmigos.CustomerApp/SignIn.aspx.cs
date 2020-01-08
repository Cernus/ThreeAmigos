using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect to Home if user is not a Guest or the Admin
            Security.RedirectIfNotGuest();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string username = usernameLabel.Text;
            string password = passwordLabel.Text;

            Security.Authenticate(username, password);
        }
    }
}