using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Entities;

namespace Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(MemberRegistrationDetail user);
        string GenerateRefreshToken();
    }
}
