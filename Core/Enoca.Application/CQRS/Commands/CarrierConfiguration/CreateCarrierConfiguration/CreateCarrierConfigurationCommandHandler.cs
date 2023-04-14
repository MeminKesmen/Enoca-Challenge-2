using AutoMapper;
using Enoca.Application.Dto.CarrierConfiguration;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public CreateCarrierConfigurationCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            var carrierConfigDto = _mapper.Map<CreateCarrierConfigurationDto>(request);
            var response =await _carrierService.CreateCarrierConfigurationAsync(carrierConfigDto);
            var commandResponse = _mapper.Map<CreateCarrierConfigurationCommandResponse>(response);
            return commandResponse;
        }
    }
}
