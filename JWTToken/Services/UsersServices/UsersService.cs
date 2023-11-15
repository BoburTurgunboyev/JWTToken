using JWTToken.DataAccess;
using JWTToken.Entities;
using JWTToken.Entities.Dtos;
using JWTToken.Services.Hash;
using Microsoft.EntityFrameworkCore;

namespace JWTToken.Services.UsersServices
{
    public class UsersService : IUserService
    {
        private AuthDbContext _authDbContext;

        public UsersService(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }
        public async ValueTask<UsersDto> CreateUsersAsync(UsersDto usersDto)
        {
            Users users = new Users();
            users.UserName = usersDto.UserName;
            users.PasswordHash = Hash512.ComputeHash512(usersDto.Password);
            users.Role = usersDto.Role;
            await _authDbContext.AddAsync(users);
            await _authDbContext.SaveChangesAsync();
            return usersDto;

        }

        public async ValueTask<IEnumerable<Users>> GetUsersAsync()
        {
            IEnumerable<Users> users = await _authDbContext.Users.ToListAsync();
            return users;
        }
    }
}
