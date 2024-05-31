using FashionStoreEcommerce.Core.Application.Abstractions.Orders;
using FashionStoreEcommerce.Core.Application.Products.Services;
using FashionStoreEcommerce.Core.Domain.Orders;
using FashionStoreEcommerce.Core.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomer()
        {
            var customers = await customerService.GetAll();
            var customerDtos = customers
                .Select(CustomerDto.FromEntity);

            return Ok(customerDtos);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            var dto = CustomerDto.FromEntity(customer);
            return Ok(dto);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var entity = CustomerDto.ToEntity(customer);
            var result = await customerService.Update(entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CreateCustomerDto createCustomer)
        {
            var customer = CreateCustomerDto.ToEntity(createCustomer);
            await customerService.Add(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await customerService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

