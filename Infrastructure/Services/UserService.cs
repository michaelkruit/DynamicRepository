using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : DynamicCrud<User>, IUserService
    {
        public UserService(UserDataDbContext dbContext)
            :base(dbContext)
        {
        }

        public async Task<User> GetUser(int id, CancellationToken cancellationToken)
        {
            // map to model
            return await GetSingle(x => x.Id == id, cancellationToken);
        }

        public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
        {
            // map to entity
            var created = await Create(user);

            // map to model
            return created;
        }

        public async Task<User> UpdateUser(int id, User user, CancellationToken cancellationToken)
        {
            // map to entity
            var updated = await Update(user);

            // map to model
            return updated;
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var user = await GetSingle(x => x.Id == id, cancellationToken);
            await Delete(user);
        }
    }
}
