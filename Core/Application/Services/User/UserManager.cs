using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserRepository;

namespace Application.Services.User
{
    public class UserManager : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UserManager(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public Task<Domain.Entities.User> AddAsync(Domain.Entities.User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User> UpdateAsync(Domain.Entities.User entity)
        {
            throw new NotImplementedException();
        }
    }
}
