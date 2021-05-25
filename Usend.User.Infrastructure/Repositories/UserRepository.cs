using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;
using Usend.UserApi.Domain.Interfaces;
using Usend.UserApi.Infrastructure.Contexts;

namespace Usend.UserApi.Infrastructure.Repositories
{
    class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainContext context)
            : base(context) { }

        public async Task<User> GetByEmailAsync(string email)
            => await DbSet.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetByCPFAsync(string cpf)
            => await DbSet.FirstOrDefaultAsync(x => x.CPF == cpf);

        public async Task<User> GetByEmailPasswordAsync(string email, string password)
            => await DbSet.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}
