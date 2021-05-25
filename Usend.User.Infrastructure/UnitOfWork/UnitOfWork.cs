using System;
using Usend.UserApi.Domain.Interfaces;
using Usend.UserApi.Infrastructure.Contexts;
using Usend.UserApi.Infrastructure.Repositories;

namespace Usend.UserApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(_context);

        public bool Commit()
            => _context.SaveChanges() > 0;

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
