using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class Security
    {
        private static readonly int adminCustomerId = 1;

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

        // TODO (Reconfigure to be checkiflogged in; true or false)
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