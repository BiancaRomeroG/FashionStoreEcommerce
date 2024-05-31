using FashionStoreEcommerce.Core.Application.Abstractions.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController(IOrderItemService orderItemService) : ControllerBase
    {
        
            // GET: api/OrderItems
            [HttpGet]
            public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItem()
            {
                var orderItems = await orderItemService.GetAll();
                var orderItemDtos = orderItems
                    .Select(OrderItemDto.FromEntity);
                return Ok(orderItemDtos);
            }

            // GET: api/OrderItems/5
            [HttpGet("{id}")]
            public async Task<ActionResult<OrderItemDto>> GetOrderItem(int id)
            {
                var orderItem = await orderItemService.GetById(id);

                if (orderItem == null)
                {
                    return NotFound();
                }

                var dto = OrderItemDto.FromEntity(orderItem);
                return Ok(dto);
            }

            // PUT: api/OrderItems/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutOrderItem(int id, OrderItemDto orderItem)
            {
                if (id != orderItem.Id)
                {
                    return BadRequest();
                }

                var entity = OrderItemDto.ToEntity(orderItem);
                var result = await orderItemService.Update(entity);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }

            // POST: api/OrderItems
            [HttpPost]
            public async Task<ActionResult<OrderItemDto>> PostOrderItem(CreateOrderItemDto createOrderItem)
            {
                var orderItem = CreateOrderItemDto.ToEntity(createOrderItem);
                await orderItemService.Add(orderItem);

                return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
            }

            // DELETE: api/OrderItems/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOrderItem(int id)
            {
                var result = await orderItemService.Delete(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }

        }
}
