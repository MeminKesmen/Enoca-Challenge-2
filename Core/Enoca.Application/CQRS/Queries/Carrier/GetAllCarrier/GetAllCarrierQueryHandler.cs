using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQueryRequest, GetAllCarrierQueryResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public GetAllCarrierQueryHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<GetAllCarrierQueryResponse> Handle(GetAllCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierService.GetAllCarrierAsync();
            return new() {
                CarrierList = response,
                Count = response.Data.Count(),
                Message = response.Message,
                Success=response.Success
            };
        }
    }
}
