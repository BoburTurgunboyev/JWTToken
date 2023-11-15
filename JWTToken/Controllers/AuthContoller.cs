using JWTToken.Entities.Dtos;
using JWTToken.Entities;
using JWTToken.Services.Hash;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTToken.Services.UsersServices;
using JWTToken.Services.AuthServices;

namespace JWTToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private IUserService _userService;
        private IAuthServices _authServices;

        public AuthContoller(IUserService userService,IAuthServices authServices)
        {
            _userService = userService;
            _authServices = authServices;
        }



        [HttpPost]
        public async ValueTask<IActionResult> Login(UsersDto createDto)
        {
            IEnumerable<Users> users = await _userService.GetUsersAsync();

            Users? user = users.FirstOrDefault(x => x.UserName == createDto.UserName && x.PasswordHash == Hash512.ComputeHash512(createDto.Password));

            if (user == null)
                return NotFound("Login yo password hato");

            string token = _authServices.GenerateToken(createDto);

            return Ok(token);
        }

        [HttpPost]

        public async ValueTask<IActionResult> Register(UsersDto registerDto)
        {
             var userrr = await _userService.CreateUsersAsync(registerDto);
            return Ok(_authServices.GenerateToken(userrr));
        }
    }
}
