using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.CarrierConfiguration.GetCarrierConfiguration
{
    public class GetCarrierConfigurationQueryHandler : IRequestHandler<GetCarrierConfigurationQueryRequest, GetCarrierConfigurationQueryResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public GetCarrierConfigurationQueryHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<GetCarrierConfigurationQueryResponse> Handle(GetCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierService.GetCarrierConfigurationAsync(cc => cc.Id == request.Id);
            return new()
            {
                CarrierConfiguration = response.Data,
                Message = response.Message,
                Success = response.Success
            };
        }
    }
}
