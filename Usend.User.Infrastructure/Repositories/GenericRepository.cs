using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;
using Usend.UserApi.Domain.Interfaces;
using Usend.UserApi.Infrastructure.Contexts;

namespace Usend.UserApi.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MainContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(MainContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async void Add(T obj)
        {
            obj.CreatedOn = DateTime.Now;
            DbSet.Add(obj);
        }

        public void Update(T obj)
        {
            obj.UpdatedOn = DateTime.Now;
            DbSet.Update(obj);
        }

        public void Remove(T obj)
            => DbSet.Remove(obj);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await DbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsNoTrackingAsync()
            => await DbSet.AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await DbSet.FindAsync(id);
    }
}
