using FashionStoreEcommerce.Core.Application.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayment()
        {
            var payments = await paymentService.GetAll();
            var paymentDtos = payments
                .Select(PaymentDto.FromEntity);

            return Ok(paymentDtos);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            var payment = await paymentService.GetById(id);

            if (payment == null)
            {
                return NotFound();
            }

            var dto = PaymentDto.FromEntity(payment);
            return Ok(dto);
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, PaymentDto payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            var entity = PaymentDto.ToEntity(payment);
            var result = await paymentService.Update(entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> PostPayment(CreatePaymentDto createPayment)
        {
            var payment = CreatePaymentDto.ToEntity(createPayment);
            await paymentService.Add(payment);

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await paymentService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
