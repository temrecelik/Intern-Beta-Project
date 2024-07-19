using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T>  where T : class
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        Task<bool> Update(T model);

        bool Remove(T model);

        bool RemoveRange(List<T> datas);

        Task<bool> RemoveAsync(Guid id); //convert guid 

        //Task<int> SaveAsync(T model);
    }
}
