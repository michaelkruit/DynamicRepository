using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserService : IDynamicCrud<User>
    {
        Task<User> GetUser(int id, CancellationToken cancellationToken);
        Task<User> CreateUser(User user, CancellationToken cancellationToken);
        Task<User> UpdateUser(int id, User user, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);
    }
}
