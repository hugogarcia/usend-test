using System;

namespace Usend.UserApi.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        bool Commit();
    }
}
