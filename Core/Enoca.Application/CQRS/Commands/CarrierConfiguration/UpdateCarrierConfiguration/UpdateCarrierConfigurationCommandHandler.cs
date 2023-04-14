using AutoMapper;
using Enoca.Application.Dto.CarrierConfiguration;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public UpdateCarrierConfigurationCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            var carrierConfigDto = _mapper.Map<UpdateCarrierConfigurationDto>(request);
            var response =await _carrierService.UpdateCarrierConfigurationAsync(carrierConfigDto);
            var commandResponse = _mapper.Map<UpdateCarrierConfigurationCommandResponse>(response);
            return commandResponse;
        }
    }
}
