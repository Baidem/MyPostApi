using Entities;
using Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        MyPostApiContext context;
        ILogger<UserRepository> logger;

        public UserRepository(MyPostApiContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await context.Users.ToListAsync();
            List<UserDto> userDtoList = new List<UserDto>();
            foreach (var user in users)
            {
                userDtoList.Add(ConvertUserToDto(user));
            }
            return userDtoList;
        }

        private UserDto ConvertUserToDto(User user)
        {
            var userDto = new UserDto { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email};

            return userDto;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> AddUserAsync(User user)
        {
            try
            {
                await context.Users.AddAsync(user);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
            return user;
        }

        public async Task<User?> ModifyUserAsync(User param)
        {
            try
            {
                User? user = await context.Users.FindAsync(param.Id);
                if (user != null)
                {
                    user.FirstName = param.FirstName;
                    user.LastName = param.LastName;
                    user.Email = param.Email;
                    user.Password = param.Password;

                    await context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    logger.LogError("Item not found");

                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
        }

        public async Task<User?> RemoveUserAsync(int id)
        {
            try
            {
                User? user = await context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);

                    await context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    logger.LogError("Item not found");

                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> LoginUser(string email, string password)
        {
            return context.Users.Where(u => u.Password == password && u.Email == email).FirstOrDefault();
        }

    }
}
