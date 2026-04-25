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
    public interface IAuthRepository
    {
        Task<MemberRegistrationDetail?> GetUserAsync(string username, string password);
        Task SaveRefreshTokenAsync(RefreshToken token);
    }
}
