using FashionStoreEcommerce.Core.Application.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrder()
        {
            var orders = await orderService.GetAll();
            var orderDtos = orders
                .Select(OrderDto.FromEntity);

            return Ok(orderDtos);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var dto = OrderDto.FromEntity(order);
            return Ok(dto);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var entity = OrderDto.ToEntity(order);
            var result = await orderService.Update(entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(CreateOrderDto createOrder)
        {
            var order = CreateOrderDto.ToEntity(createOrder);
            await orderService.Add(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await orderService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
