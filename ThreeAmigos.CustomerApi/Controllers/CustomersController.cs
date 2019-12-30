using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApi.Models;
using ThreeAmigos.CustomerApi.Repositories;

namespace ThreeAmigos.CustomerApi.Controllers
{
    //[Route("api/customers")]
    [Route("api/customers/{action}")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // TODO: Delete this once repository is fully implemented
        private readonly CustomerContext _context;
        public ICustomerRepository _customerRepository { get; set; }

        // TODO: Remove context from signiture
        public CustomersController(CustomerContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;

            if (_context.Customers.Count() == 0)
            {
                // Create a new Customer if collection is empty,
                // which means you can't delete all Customers.
                _ = _context.Customers.Add(new Customer
                {
                    Username = "Admin",
                    Password = "password",
                    FirstName = "Joe",
                    SecondName = "Bloggs",
                    Address = "49 Balsham Road,Harrold,MK43 5XZ",
                    EmailAddress = "johndoe@gmail.com",
                    Tel = "07015234278",
                    Registered = Convert.ToDateTime("2010-08-14  12:33:36.590"),
                    LastOnline = Convert.ToDateTime("2010-08-14  12:33:36.590"),
                    Sell_To = true,
                    Active = true
                });
                _context.SaveChanges();
            }
        }

        // TODO: Not not implemented/used
        // GET: api/Customers/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Details()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/Detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailDto>> Detail(int id)
        {
            CustomerDetailDto customerDto = await _customerRepository.GetCustomer(id);

            if (customerDto == null)
            {
                return NotFound();
            }

            return customerDto;
        }

        // TODO: Create private method that checks entity == null etc
        // POST: api/Customers/Create
        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromBody]CustomerUpdateDto customer)
        {
            Customer entity = await _customerRepository.CreateCustomer(customer);

            if (entity == null)
            {
                return NotFound("Customer with Username = " + customer.Username + " not found to update.");
            }

            if (customer.Username != entity.Username)
            {
                return BadRequest();
            }

            return Ok(entity);

        }

        // PUT: api/Customers/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CustomerUpdateDto customer)
        {
            Customer entity = await _customerRepository.UpdateCustomer(id, customer);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // PUT api/Customers/RequestDelete/5
        [HttpPut("{id}")]
        public async Task<IActionResult> RequestDelete(int id)
        {
            Customer entity = await _customerRepository.RequestDelete(id);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // PUT api/Customers/SoftDelete/5
        [HttpPut("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Customer entity = await _customerRepository.SoftDelete(id);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // PUT api/Customers/HardDelete/5
        [HttpPut("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            Customer entity = await _customerRepository.HardDelete(id);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to delete.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // GET api/Customers/UpdateSellTo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSellTo(int id, bool sell_To)
        {
            Customer entity = await _customerRepository.UpdateSellTo(id, sell_To);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // GET api/Customers/HasAddressAndTel/5
        [HttpGet("{id}")]
        public async Task<bool> HasAddressAndTel(int id)
        {
            bool valid = await _customerRepository.HasAddressAndTel(id);

            return valid;
        }
    }
}
