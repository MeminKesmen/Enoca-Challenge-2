using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQueryRequest, GetCarrierQueryResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public GetCarrierQueryHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<GetCarrierQueryResponse> Handle(GetCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierService.GetCarrierAsync(c => c.Id == request.Id);
            return new()
            {
                Carrier = response.Data,
                Message = response.Message,
                Success = response.Success
            };

        }
    }
}
