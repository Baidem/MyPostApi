using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
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
    }
}
