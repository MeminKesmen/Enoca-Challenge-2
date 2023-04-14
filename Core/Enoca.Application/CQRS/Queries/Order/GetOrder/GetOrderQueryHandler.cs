using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Order.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var response =await _orderService.GetOrderAsync(o=>o.Id==request.Id);
            return new() {
                Order=response.Data,
                Message=response.Message,
                Success=response.Success
            };
        }
    }
}
