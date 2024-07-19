using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;
using Domain.Entities.Common;

namespace Persistence.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity<Guid>
    {
        private readonly OrderManagementDbContext _context;

        public WriteRepository(OrderManagementDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();


        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            //await SaveAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            T models = (await Table.FirstOrDefaultAsync(data => data.Id == id))!;
            return Remove(models);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        //public async Task<int> SaveAsync(T model)
        //=> await _context.SaveChangesAsync();

        public async Task<bool> Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
