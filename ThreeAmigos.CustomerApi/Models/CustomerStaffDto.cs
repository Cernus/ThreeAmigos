using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigos.CustomerApi.Models
{
    public class CustomerStaffDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Tel { get; set; }
        public bool Sell_To { get; set; }
        public DateTime RegistrationTime {get; set;}
        public DateTime LastVisit { get; set; }
    }
}
