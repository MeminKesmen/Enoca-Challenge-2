using AutoMapper;
using Enoca.Application.Dto.Order;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var orderDto = _mapper.Map<UpdateOrderDto>(request);
            var response =await _orderService.UpdateOrderAsync(orderDto);
            var commandResponse = _mapper.Map<UpdateOrderCommandResponse>(response);
            return commandResponse;
        }
    }
}
