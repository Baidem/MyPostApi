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
        Task<UserDto?> GetUserAsync(int id);
        Task<UserDto?> AddUserAsync(UserDto userDto);
        Task<User?> ModifyUserAsync(User param);
        Task<User?> RemoveUserAsync(int id);
        Task<User> LoginUser(string login, string pwd);
    }
}
