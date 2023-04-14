using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Commands
{
    public class CommandBaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
