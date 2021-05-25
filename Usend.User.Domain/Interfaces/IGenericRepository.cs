using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;

namespace Usend.UserApi.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsNoTrackingAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
