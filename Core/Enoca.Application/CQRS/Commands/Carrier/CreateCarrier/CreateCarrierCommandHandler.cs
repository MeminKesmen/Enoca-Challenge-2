using AutoMapper;
using Enoca.Application.Dto.Carrier;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public CreateCarrierCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var carrierDto = _mapper.Map<CreateCarrierDto>(request);
            var response =await  _carrierService.CreateCarrierAsync(carrierDto);
            var commandResponse = _mapper.Map<CreateCarrierCommandResponse>(response);
            return commandResponse;
        }
    }
}
