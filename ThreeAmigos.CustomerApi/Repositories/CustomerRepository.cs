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

        public async Task<List<CustomerStaffDto>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            var customersDto = customers.Select(c => new CustomerStaffDto
            {
                CustomerId = c.CustomerId,
                FullName = c.FirstName + " " + c.SecondName,
                Address = c.Address,
                EmailAddress = c.EmailAddress,
                Tel = c.Tel,
                Sell_To = c.Sell_To,
                RegistrationTime = c.Registered,
                LastVisit = c.LastOnline
            }).ToList();

            return customersDto;
        }

        public async Task<List<CustomerStaffDto>> GetRequestedDelete()
        {
            List<Customer> customers = await _context.Customers
                .Where(c => c.RequestedDelete == true)
                .ToListAsync();

            var customersDto = customers.Select(c => new CustomerStaffDto
            {
                CustomerId = c.CustomerId,
                FullName = c.FirstName + " " + c.SecondName,
                Address = c.Address,
                EmailAddress = c.EmailAddress,
                Tel = c.Tel,
                Sell_To = c.Sell_To,
                RegistrationTime = c.Registered,
                LastVisit = c.LastOnline
            }).ToList();

            return customersDto;
        }

        public async Task<CustomerDetailDto> GetCustomer(int id)
        {
            Customer customer = await _context.Customers
                .Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();

            if (customer != null)
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

        public async Task<string> GetCustomerName(int id)
        {
            Customer customer = await _context.Customers
                .Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();

            return customer.Username;
        }

        public async Task<CustomerStaffDto> GetCustomerForStaffApi(int id)
        {
            Customer customer = await _context.Customers
                .Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();

            if (customer != null)
            {
                return new CustomerStaffDto
                {
                    CustomerId = customer.CustomerId,
                    FullName = customer.FirstName + " " + customer.SecondName,
                    Address = customer.Address,
                    EmailAddress = customer.EmailAddress,
                    Tel = customer.Tel,
                    Sell_To = customer.Sell_To,
                    RegistrationTime = customer.Registered,
                    LastVisit = customer.LastOnline
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
                entity.RequestedDelete = false;

                _context.Add(entity);
                // TODO: Should all other SaveChanges() be SaveChangesAsync()?
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
            _ = entity.RequestedDelete = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> SoftDelete(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            _ = entity.Active == false;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> HardDelete(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CustomerStaffDto> UpdateSellTo(int id, bool sell)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);

            entity.Sell_To = sell;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            CustomerStaffDto customerDto = new CustomerStaffDto
            {
                CustomerId = entity.CustomerId,
                FullName = entity.FirstName + " " + entity.SecondName,
                Address = entity.Address,
                EmailAddress = entity.EmailAddress,
                Tel = entity.Tel,
                Sell_To = sell,
                RegistrationTime = entity.Registered,
                LastVisit = entity.LastOnline
            };

            return customerDto;
        }

        // TODO: Currently not implemented/used
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> HasAddressAndTel(int id)
        {
            Customer entity = await _context.Customers.FirstAsync(c => c.CustomerId == id);
            if (entity.Address != null && entity.Tel != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<int> Authenticate(string username, string password)
        {
            try
            {
                Customer entity = await _context.Customers.FirstAsync(c => c.Username == username && c.Password == password);
                return entity.CustomerId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
