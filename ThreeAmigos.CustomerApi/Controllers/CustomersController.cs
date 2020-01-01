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
        public ICustomerRepository _customerRepository { get; set; }
        public IProductRepository _productRepository { get; set; }

        public CustomersController(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        // GET: api/Customers/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Details()
        {
            //return await _context.Customers.ToListAsync();
            List<Customer> customers = await _customerRepository.GetCustomers();
            return customers;
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
                return NotFound("Customer with Username = " + customer.Username + " was unable to be created");
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

        // GET: api/Customers/ProductDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> ProductDetail(int id)
        {
            ProductDto productDto = await _productRepository.GetProduct(id);

            if (productDto == null)
            {
                return NotFound();
            }

            return productDto;
        }

        // GET: api/Customers/GetProductId/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> ProductId(int id)
        {
            ProductDto productDto = await _productRepository.GetProduct(id);

            if (productDto != null)
            {
                return Ok(productDto.ProductId);
            }
            else
            {
                return Ok(null);
            }
        }

        // POST: api/Customers/CreateProduct
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody]ProductDto product)
        {
            ProductDto entity = await _productRepository.CreateProduct(product);

            if (entity == null)
            {
                return NotFound("A Product with ProductId = " + product.ProductId + " was unable to be created.");
            }

            if (product.Name != entity.Name)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        // PUT: api/Customers/UpdateProduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]ProductDto product)
        {
            ProductDto entity = await _productRepository.UpdateProduct(product);

            if (entity == null)
            {
                return NotFound("Product with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.ProductId)
            {
                return BadRequest();
            }

            return Ok(entity);
        }
    }
}
