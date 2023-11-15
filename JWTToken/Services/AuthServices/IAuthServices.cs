using JWTToken.Entities.Dtos;

namespace JWTToken.Services.AuthServices
{
    public interface IAuthServices
    {
        public string GenerateToken(UsersDto usersDto);
    }
}
