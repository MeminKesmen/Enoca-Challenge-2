using Enoca.Application.CQRS.Commands.Carrier.CreateCarrier;
using Enoca.Application.CQRS.Commands.Carrier.DeleteCarrier;
using Enoca.Application.CQRS.Commands.Carrier.UpdateCarrier;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.DeleteCarrierConfiguration;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using Enoca.Application.CQRS.Queries.Carrier.GetAllCarrier;
using Enoca.Application.CQRS.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarrierController : BaseController
    {
        public CarrierController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarrier()
        {
            var response = await _mediator.Send(new GetAllCarrierQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarrier(CreateCarrierCommandRequest createCarrierCommandRequest) 
        {
            var response = await _mediator.Send(createCarrierCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCarrier([FromQuery]DeleteCarrierCommandRequest deleteCarrierCommandRequest)
        {
            var response = await _mediator.Send(deleteCarrierCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCarrier(UpdateCarrierCommandRequest updateCarrierCommandRequest)
        {
            var response = await _mediator.Send(updateCarrierCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarrierConfiguration()
        {
            var response = await _mediator.Send(new GetAllCarrierConfigurationQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarrierConfiguration(CreateCarrierConfigurationCommandRequest createCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCarrierConfiguration([FromQuery]DeleteCarrierConfigurationCommandRequest deleteCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(deleteCarrierConfigurationCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCarrierConfiguration(UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(updateCarrierConfigurationCommandRequest);
            return Ok(response);
        }
    }
}
