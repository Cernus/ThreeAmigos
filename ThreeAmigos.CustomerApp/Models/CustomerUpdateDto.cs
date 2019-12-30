using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.CustomerApp
{
    public class CustomerUpdateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Tel { get; set; }
    }
}