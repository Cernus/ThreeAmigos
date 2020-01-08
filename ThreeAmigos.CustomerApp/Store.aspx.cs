using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using Newtonsoft.Json;
using ThreeAmigos.ProductFacade;
using System.Web.UI.WebControls;
using ThreeAmigos.CustomerApp.Services;

//https://devblogs.microsoft.com/aspnet/use-dependency-injection-in-webforms-application/
namespace ThreeAmigos.CustomerApp
{
    public partial class Store : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // No Security
                PopulatePage();
                PopulateDDL();
            }
        }

        // Generate rows on GridView from Json object
        private void PopulatePage()
        {
            StoreGridView.DataSource = ProductService.GetProducts();
            StoreGridView.DataBind();
        }

        // Adds elements to the Drop Down List
        private void PopulateDDL()
        {
            string[] columns = { "Name", "Category Name", "Brand Name", "Description" };

            foreach(string column in columns)
            {
                SearchFilterDDL.Items.Add(new ListItem(column));
            }
        }
    }
}