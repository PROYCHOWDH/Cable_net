using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MemberRegistrationDetail?> GetUserAsync(string username, string password)
        {
            return await _context.MemberRegistrationDetails
                .FirstOrDefaultAsync(x => x.UserId == username && x.Password == password);
        }

        public async Task SaveRefreshTokenAsync(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }
    }
}
