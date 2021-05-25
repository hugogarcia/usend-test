using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;

namespace Usend.UserApi.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByCPFAsync(string cpf);
        Task<User> GetByEmailPasswordAsync(string email, string password);
    }
}
