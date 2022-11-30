using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace MyPostApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await userRepository.GetUserAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var userCreated = await userRepository.AddUserAsync(user);

            if (userCreated != null)
                return Ok(userCreated);
            else
                return Problem("User not created");
        }
        [HttpPut]
        public async Task<ActionResult<User>> ModifyUser(User param)
        {
            var userModified = await userRepository.ModifyUserAsync(param);

            if (userModified != null)
                return Ok(userModified);
            else
                return Problem("User not modified");
        }
        [HttpDelete]
        public async Task<ActionResult<User>> RemoveUser(int id)
        {
            var userRemoved = await userRepository.RemoveUserAsync(id);
            if (userRemoved != null)
                return Ok(userRemoved);
            else
                return Problem("User not removed");
        }

    }
}
