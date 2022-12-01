﻿using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using System.ComponentModel;
using System.Security.Claims;

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
        [HttpGet]
        public async Task<IActionResult> LoginAsync(
            [DefaultValue("Jerry.Seinfeld@aol.com")] string login,
            [DefaultValue("password")] string pwd)
        {
            var UserCreated = await userRepository.LoginUser(login, pwd);
            if (UserCreated == null)
                return Problem($"Erreur lors du login, vérifiez le login ou mot de passe");
            Claim emailClaim = new(ClaimTypes.Email, UserCreated.Email);
            Claim nameClaim = new(ClaimTypes.Name, UserCreated.LastName);
            Claim gvClaim = new(ClaimTypes.GivenName, UserCreated.FirstName);
            Claim idClaim = new(ClaimTypes.NameIdentifier, UserCreated.Id.ToString());
            ClaimsIdentity identity = new(new List<Claim> {
                        emailClaim,
                        nameClaim,
                        gvClaim,
                        idClaim
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return Ok($"{UserCreated.LastName} logged");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok("Logout");
        }

    }
}
