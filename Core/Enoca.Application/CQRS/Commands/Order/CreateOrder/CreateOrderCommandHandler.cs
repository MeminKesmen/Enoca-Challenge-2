using AutoMapper;
using Enoca.Application.Dto.Order;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var orderDto = _mapper.Map<CreateOrderDto>(request);
            var response = await _orderService.CreateOrderAsync(orderDto);
            var commandResponse = _mapper.Map<CreateOrderCommandResponse>(response);
            return commandResponse;
        }
    }
}
