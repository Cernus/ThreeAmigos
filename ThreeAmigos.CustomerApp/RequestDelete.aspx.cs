using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

namespace ThreeAmigos.CustomerApp
{
    public partial class RequestDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Redirect if is Guest
                Security.RedirectIfIsGuest();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            UserService.RequestDelete();
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Security.RedirectToPreviousPage();
        }
    }
}