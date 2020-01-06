using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApi.Models;
using ThreeAmigos.CustomerApi.Repositories;

// TODO: Should Products stuff be in their own controller?
namespace ThreeAmigos.CustomerApi.Controllers
{
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
        public async Task<ActionResult<IEnumerable<CustomerStaffDto>>> Details()
        {
            List<CustomerStaffDto> customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        // GET: api/Customers/GetRequestedDelete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerStaffDto>>> GetRequestedDelete()
        {
            List<CustomerStaffDto> customers = await _customerRepository.GetRequestedDelete();
            return Ok(customers);
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

            return Ok(customerDto);
        }

        // GET: api/Customers/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerStaffDto>> Get(int id)
        {
            CustomerStaffDto customerDto = await _customerRepository.GetCustomerForStaffApi(id);

            if (customerDto == null)
            {
                return NotFound();
            }

            return Ok(customerDto);
        }

        // GET api/Customers/CustomerName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> CustomerName(int id)
        {
            string customerName = await _customerRepository.GetCustomerName(id);

            if(customerName == null)
            {
                return NotFound();
            }

            return Ok(customerName);
        }

        // GET api/Customers/CustomerNames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerName>>> CustomerNames()
        {
            List<CustomerName> customers = await _customerRepository.GetCustomerNames();
            return Ok(customers);
        }

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

        // DELETE api/Customers/HardDelete/5
        [HttpDelete("{id}")]
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

        // PUT api/Customers/UpdateSellTo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSellTo(int id, [FromBody]string json)
        {
            // TODO: Put this code in repository
            bool flag = false;
            try
            {
                flag = json.Contains("true");
            }
            catch
            {
                return BadRequest("Could not convert json to bool");
            }

            CustomerStaffDto entity = await _customerRepository.UpdateSellTo(id, flag);

            if (entity == null)
            {
                return NotFound("Customer with Id = " + id.ToString() + " not found to update.");
            }

            if (id != entity.CustomerId)
            {
                return BadRequest("Id of cusstomer does not match database");
            }

            return Ok(entity);
        }

        // GET api/Customers/DeliveryDetails/5
        [HttpGet("{id}")]
        public async Task<bool> DeliveryDetails(int id)
        {
            bool valid = await _customerRepository.HasDeliveryDetails(id);

            return valid;
        }

        // POST api/customers/authenticate
        [HttpPost]
        public async Task<int> Authenticate([FromBody]List<string> authDetails)
        {
            int userId = await _customerRepository.Authenticate(authDetails[0], authDetails[1]);

            return userId;
        }

        // GET: api/Customers/ProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductDetails()
        {
            List<ProductDto> products = await _productRepository.GetProducts();
            return Ok(products);
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

            return Ok(productDto);
        }

        // GET: api/Customers/GetProductId/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> ProductId(int id)
        {
            ProductDto productDto = await _productRepository.GetProduct(id);

            if (productDto != null)
            {
                return Ok(productDto.Id);
            }
            else
            {
                return Ok(null);
            }
        }

        // GET: api/Customers/GetProductName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> ProductName(int id)
        {
            ProductDto productDto = await _productRepository.GetProduct(id);

            if (productDto != null)
            {
                return Ok(productDto.Name);
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
                return NotFound("A Product with ProductId = " + product.Id + " was unable to be created.");
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

            if (id != entity.Id)
            {
                return BadRequest();
            }

            return Ok(entity);
        }
    }
}
