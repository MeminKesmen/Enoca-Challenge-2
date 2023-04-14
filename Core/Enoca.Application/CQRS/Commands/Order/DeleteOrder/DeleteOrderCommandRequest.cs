using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandRequest:IRequest<DeleteOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}
