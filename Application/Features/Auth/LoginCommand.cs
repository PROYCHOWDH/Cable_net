using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.Auth
{
    public record LoginCommand(string UserName, string Password) : IRequest<string>;
}
