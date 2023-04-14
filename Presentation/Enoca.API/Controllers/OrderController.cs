using Enoca.Application.CQRS.Commands.Order.CreateOrder;
using Enoca.Application.CQRS.Commands.Order.DeleteOrder;
using Enoca.Application.CQRS.Queries.Order.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _mediator.Send(new GetAllOrderQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            var response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            var response = await _mediator.Send(deleteOrderCommandRequest);
            return Ok(response);
        }
       
    }
}
