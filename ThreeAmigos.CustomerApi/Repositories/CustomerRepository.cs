using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApi.Models;

//https://medium.com/@gabrymartinez/how-to-create-your-own-little-restful-web-api-and-not-get-lost-in-the-process-part-2-473400256ce0

namespace ThreeAmigos.CustomerApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        // TODO
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<CustomerDetailDto> GetCustomer(int id)
        {
            Customer customer = await _context.Customers
                .Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();

            if(customer != null)
            {
                return new CustomerDetailDto
                {
                    Username = customer.Username,
                    Password = customer.Password,
                    FirstName = customer.FirstName,
                    SecondName = customer.SecondName,
                    Address = customer.Address,
                    EmailAddress = customer.EmailAddress,
                    Tel = customer.Tel,
                    Sell_To = customer.Sell_To
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Customer> UpdateCustomer(int id, CustomerUpdateDto customer)
        {
            try
            {
                Customer entity = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

                entity.Username = customer.Username;
                entity.Password = customer.Password;
                entity.FirstName = customer.FirstName;
                entity.SecondName = customer.SecondName;
                entity.Address = customer.Address;
                entity.EmailAddress = customer.EmailAddress;
                entity.Tel = customer.Tel;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer> CreateCustomer(CustomerUpdateDto customer)
        {
            try
            {
                Customer entity = new Customer();
                entity.Username = customer.Username;
                entity.Password = customer.Password;
                entity.FirstName = customer.FirstName;
                entity.SecondName = customer.SecondName;
                entity.Address = customer.Address;
                entity.EmailAddress = customer.EmailAddress;
                entity.Tel = customer.Tel;
                entity.Registered = DateTime.Now.Date;
                entity.LastOnline = DateTime.Now.Date;
                entity.Sell_To = true;
                entity.Active = true;

                _context.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer> RequestDelete(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            // TODO: Send request to StaffApi
            return entity;
        }

        public async Task<Customer> SoftDelete(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            _ = entity.Active == false;
            _context.SaveChanges();

            return entity;
        }

        public async Task<Customer> HardDelete(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            _context.Customers.Remove(entity);

            return entity;
        }
                
        public async Task<Customer> UpdateSellTo(int id, bool sell)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            _ = entity.Sell_To == sell;
            _context.SaveChanges();

            return entity;
        }

        // TODO: Currently not implemented/used
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> HasAddressAndTel(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            if(entity.Address != null && entity.Tel != null)
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
