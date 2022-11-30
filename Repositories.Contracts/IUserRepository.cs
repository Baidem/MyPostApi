using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User?> ModifyUserAsync(User param);
        Task<User?> RemoveUserAsync(int id);
    }
}
