using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ThreeAmigos.CustomerApp.Models;
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
            int userId = customerFac.Authenticate(username, password);

            if (userId > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(userId.ToString(), true);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("~/Default");
        }

        // Redirect to Home Page if Current User is not owner of page or the Admin
        public static void RedirectIfNoPermissions()
        {
            try
            {
                string queryString = HttpContext.Current.Request.QueryString["id"];
                int pageId = Int32.Parse(queryString);

                int userId = UserService.GetUserId();

                // Redirect if Not logged in, page has no query string or Customer goes not exist
                RedirectIfInvalidCustomerId();
                if (userId == 0 || pageId == 0)
                {
                    HttpContext.Current.Response.Redirect("~/Default");
                }

                bool idsMatch = (pageId == userId);

                if (!(idsMatch || IsAdmin()))
                {
                    HttpContext.Current.Response.Redirect("~/Default");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfNotGuest()
        {
            bool isLoggedIn = IsLoggedIn();
            
            if (isLoggedIn && !IsAdmin())
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfIsGuest()
        {
            bool isLoggedIn = IsLoggedIn();

            if(!isLoggedIn)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfInvalidCustomerId()
        {
            try
            {
                // Check query string is an int
                string queryString = HttpContext.Current.Request.QueryString["id"];
                int pageId = Int32.Parse(queryString);

                // Check that int belongs to a customer in the database
                UserService.GetCustomer();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfInvalidProductId()
        {
            try
            {
                string queryString = HttpContext.Current.Request.QueryString["id"];
                int pageId = Int32.Parse(queryString);
                ProductService.GetProduct(pageId);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void RedirectIfReviewExists()
        {
            if(!IsAdmin() && ReviewService.ReviewExists())
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }

        public static void MemoriseCurrentPage(string previousPage)
        {
            //HttpContext.Current.Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            HttpContext.Current.Session["url"] = previousPage;
        }

        public static void RedirectToPreviousPage()
        {
            string absolutePath = "~/Default";
            try
            {
                absolutePath = HttpContext.Current.Session["url"].ToString();
            }
            catch
            {

            }

            HttpContext.Current.Response.Redirect(absolutePath);
        }
        public static bool CheckIfValidPreviousPage(object validPreviousPage)
        {
            // Get previous page as a string
            string previousPage = HttpContext.Current.Session["url"].ToString();

            // Set new Previous Page
            //MemoriseCurrentPage();

            // Redirect if previous page is not the validPreviousPage
            if (validPreviousPage.ToString() == previousPage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetAdminCustomerId()
        {
            return adminCustomerId;
        }

        // Return true if current user is the Admin
        public static bool IsAdmin()
        {
            try
            {
                return UserService.GetUserId() == GetAdminCustomerId();
            }
            catch
            {
                return false;
            }
        }

        // Return true if the current user is logged in
        public static bool IsLoggedIn()
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}