using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // 🔴 Replace with DB check
            if (request.UserName != "admin" || request.Password != "1234")
                throw new UnauthorizedAccessException("Invalid credentials");

            var user = new AppUser
            {
                Id = 1,
                UserName = request.UserName,
                Role = "Admin"
            };

            var token = _jwtTokenService.GenerateToken(user);
            return Task.FromResult(token);
        }
    }
}
