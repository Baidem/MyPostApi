using Entities;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User?> ModifyUserAsync(User param);
        Task<User?> RemoveUserAsync(int id);
        Task<User> LoginUser(string login, string pwd);
    }
}
