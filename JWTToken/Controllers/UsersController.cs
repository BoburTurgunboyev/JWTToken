using JWTToken.Entities;
using JWTToken.Entities.Dtos;
using JWTToken.Services.UsersServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize(Roles ="Admin,Bot")]
        [HttpGet(Name = "Users")]
        public async  ValueTask<IActionResult> GetAll()
        {
            IEnumerable<Users> users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [Authorize(Roles ="Admin,Bot")]
        [HttpPost]

        public async ValueTask<IActionResult> CreateUser(UsersDto usersDto)
        {
            var users = await _userService.CreateUsersAsync(usersDto);
            return Ok(users);   
        }
    }
}
