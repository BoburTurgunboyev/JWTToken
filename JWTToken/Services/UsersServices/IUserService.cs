using JWTToken.Entities;
using JWTToken.Entities.Dtos;

namespace JWTToken.Services.UsersServices
{
    public interface IUserService
    {
        public ValueTask<UsersDto> CreateUsersAsync(UsersDto usersDto);
        public ValueTask<IEnumerable<Users>> GetUsersAsync();
    }
}
