using System.Threading.Tasks;
using USend.UserApi.Application.Dto;

namespace USend.UserApi.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<JwtDto> Authorize(AuthenticationDto authenticationDto);
    }
}