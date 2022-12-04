﻿using Entities;
using Dto;
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
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var userDtoList = await userRepository.GetAllUsersAsync();

            return Ok(userDtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var userDto = await userRepository.GetUserAsync(id);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(string firstName, string lastName, string email, string password)
        {
            var IsExistEmail = await userRepository.IsExistEmailAsync(email);
            if (IsExistEmail)
                return Problem("This email is already in use.");
            UserDto userDto = new UserDto
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            var userCreated = await userRepository.AddUserAsync(userDto, password);

            if (userCreated != null)
                return Ok(userCreated);
            else
                return Problem("User not created");
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> ModifyUser(string? firstName, string? lastName, string email, string? password)
        {
            var IsExistEmail = await userRepository.IsExistEmailAsync(email);
            if (!IsExistEmail)
                return Problem("This user does not exist, please check the email.");
            UserDto userDto = new UserDto
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            var userModified = await userRepository.ModifyUserAsync(userDto, password);

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
