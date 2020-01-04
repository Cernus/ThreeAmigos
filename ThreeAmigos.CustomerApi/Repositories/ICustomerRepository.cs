using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApi.Models;

namespace ThreeAmigos.CustomerApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> SaveAllAsync();
        Task<List<CustomerStaffDto>> GetCustomers();
        Task<List<CustomerStaffDto>> GetRequestedDelete();
        Task<CustomerDetailDto> GetCustomer(int id);
        Task<CustomerStaffDto> GetCustomerForStaffApi(int id);
        Task<Customer> UpdateCustomer(int id, CustomerUpdateDto customer);
        Task<Customer> CreateCustomer(CustomerUpdateDto customer);
        Task<Customer> RequestDelete(int id);
        Task<Customer> SoftDelete(int id);
        Task<Customer> HardDelete(int id);
        Task<CustomerStaffDto> UpdateSellTo(int id, bool sell);
        Task<bool> HasAddressAndTel(int id);
        Task<int> Authenticate(string username, string password);
    }
}
