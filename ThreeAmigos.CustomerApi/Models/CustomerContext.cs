﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ThreeAmigos.CustomerApi.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            :base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductDto> Products { get; set; }
    }
}
