using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.CarrierConfiguration.DeleteCarrierConfiguration
{
    public class DeleteCarrierConfigurationCommandHandler : IRequestHandler<DeleteCarrierConfigurationCommandRequest, DeleteCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public DeleteCarrierConfigurationCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<DeleteCarrierConfigurationCommandResponse> Handle(DeleteCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            var response =await _carrierService.DeleteCarrierConfigurationById(request.Id);
            var commandResponse = _mapper.Map<DeleteCarrierConfigurationCommandResponse>(response);
            return commandResponse;
        }
    }
}
