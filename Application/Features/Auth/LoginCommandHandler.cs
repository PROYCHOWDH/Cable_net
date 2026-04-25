using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAuthRepository _repo;
        public LoginCommandHandler(IJwtTokenService jwtTokenService, IAuthRepository repo)
        {
            _jwtTokenService = jwtTokenService;
            _repo = repo;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserAsync(request.UserName, request.Password);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

     

            var accessToken = _jwtTokenService.GenerateToken(user);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            var response = new LoginResponse(accessToken, refreshToken);

            return await Task.FromResult(response);
        }
    }
}
