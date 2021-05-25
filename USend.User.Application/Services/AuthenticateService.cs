using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Interfaces;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Interfaces;
using USend.UserApi.Secutiry;

namespace USend.UserApi.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationContext _notification;

        public AuthenticateService(
            IConfiguration configuration, 
            IUnitOfWork unitOfWork, 
            INotificationContext notification)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _notification = notification;
        }

        public async Task<JwtDto> Authorize(AuthenticationDto authenticationDto)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailPasswordAsync(authenticationDto.Email, authenticationDto.Password);
            if (user is null)
            {
                _notification.AddNotification("Invalid email or password!");
                return null;
            }

            var token = JwtGenerator.Generate(_configuration, user.Name, user.Email);

            return new JwtDto
            {
                Access_token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_in = token.ValidTo
            };
        }
    }
}
