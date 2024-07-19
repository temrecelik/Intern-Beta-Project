using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public interface IUserService
    {
        IQueryable<Domain.Entities.User> GetAll();
        Task<Domain.Entities.User> GetByIdAsync(string id);
        Task<Domain.Entities.User> AddAsync(Domain.Entities.User entity);
        Task<Domain.Entities.User> UpdateAsync(Domain.Entities.User entity);
        Task<Domain.Entities.User> DeleteAsync(string id);
    }
}
