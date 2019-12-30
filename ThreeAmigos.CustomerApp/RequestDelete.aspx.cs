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

            }
        }

        //TODO
        protected void delete_Click(object sender, EventArgs e)
        {
            CurrentUser.RequestDelete();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}