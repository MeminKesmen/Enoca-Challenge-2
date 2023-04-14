using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryHandler : IRequestHandler<GetAllCarrierConfigurationQueryRequest, GetAllCarrierConfigurationQueryResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public GetAllCarrierConfigurationQueryHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<GetAllCarrierConfigurationQueryResponse> Handle(GetAllCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierService.GetAllCarrierConfigurationAsync();
            return new()
            {
                CarrierConfigurationList = response.Data,
                Count = response.Data.Count(),
                Message = response.Message,
                Success = response.Success
            };
        }
    }
}
