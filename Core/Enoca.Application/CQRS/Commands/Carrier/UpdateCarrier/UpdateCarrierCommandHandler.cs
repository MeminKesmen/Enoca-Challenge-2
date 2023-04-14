using AutoMapper;
using Enoca.Application.Dto.Carrier;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public UpdateCarrierCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var carrierDto = _mapper.Map<UpdateCarrierDto>(request);
            var response=await _carrierService.UpdateCarrierAsync(carrierDto);
            var commandResponse = _mapper.Map<UpdateCarrierCommandResponse>(response);
            return commandResponse;
        }
    }
}
