using AutoMapper;
using Enoca.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Carrier.DeleteCarrier
{
    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommandRequest, DeleteCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;
        readonly IMapper _mapper;

        public DeleteCarrierCommandHandler(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService;
            _mapper = mapper;
        }
        public async Task<DeleteCarrierCommandResponse> Handle(DeleteCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierService.DeleteCarrierById(request.Id);
            var commandResponse = _mapper.Map<DeleteCarrierCommandResponse>(response);
            return commandResponse;
        }
    }
}
