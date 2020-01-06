using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigos.CustomerApi.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Tel { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastOnline { get; set; }
        [Required]
        public bool Sell_To { get; set; }
        [Required]
        public bool Active { get; set; }
        public bool RequestedDelete { get; set; }
    }
}
