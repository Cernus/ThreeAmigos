using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ThreeAmigos.CustomerFacade;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class Security
    {
        private static CustomerFac customerFac = new CustomerFac();
        private static readonly int adminCustomerId = 2;

        public static void Authenticate(string username, string password)
        {
            // Get row that has matching username and password
            bool userfound = customerFac.Authenticate(username, password);

            if (userfound)
            {
                // TODO: Alter this so it gets the id of the current user instead of static int

                FormsAuthentication.RedirectFromLoginPage("2", true);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfNotUsersPage()
        {
            try
            {
                string queryString = HttpContext.Current.Request.QueryString["Id"].ToString();

                // If query string is not same as user's customerId and user is not the Admin
                if(!CurrentUser.GetCustomerId().ToString().Equals(queryString) && CurrentUser.GetCustomerId() != GetAdminCustomerId())
                {
                    HttpContext.Current.Response.Redirect("~/Default");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static int GetAdminCustomerId()
        {
            return adminCustomerId;
        }

        // TODO (Reconfigure to be check if logged in; true or false)
        public static bool RedirectIfNotGuest()
        {
            if(IsGuest() || CurrentUser.GetCustomerId() == GetAdminCustomerId())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // TODO
        private static bool IsGuest()
        {
            return true;
        }
    }
}