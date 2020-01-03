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
            // TODO: Update active flag from Customer API if James does not have enough time to implement this

            CurrentUser.RequestDelete();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}