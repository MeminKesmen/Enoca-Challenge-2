using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.CarrierConfiguration.DeleteCarrierConfiguration
{
    public class DeleteCarrierConfigurationCommandRequest:IRequest<DeleteCarrierConfigurationCommandResponse>
    {
        public int Id { get; set; }
    }
}
