﻿using System;
using ThreeAmigos.CustomerFacade;

namespace ThreeAmigos.CustomerApp
{
    public class Customer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Tel { get; set; }
        public bool Sell_To { get; set; }
    }
}