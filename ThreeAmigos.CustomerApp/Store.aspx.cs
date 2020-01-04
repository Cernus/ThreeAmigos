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
            // TODO: Handle case for no response from Store Api (allow user to navigate to ProductDetail page still from here)
            // TODO: E.g. use data stored in Customer Api but display a warning that the data may be out of date
            if (!IsPostBack)
            {
                // No Security
                PopulatePage();
                PopulateDDL();
            }
        }

        // TODO: Add column to "see all reviews" for product
        // Generate rows on GridView from Json object
        private void PopulatePage()
        {
            StoreGridView.DataSource = ProductService.GetProducts();
            StoreGridView.DataBind();
        }

        // TODO: Add functionality for "All"
        // Adds elements to the Drop Down List
        private void PopulateDDL()
        {
            string[] columns = { "Name", "CategoryName", "BrandName", "Description" };

            foreach(string column in columns)
            {
                SearchFilterDDL.Items.Add(new ListItem(column));
            }
        }
    }
}