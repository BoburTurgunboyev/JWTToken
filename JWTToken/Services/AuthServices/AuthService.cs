using JWTToken.Entities.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTToken.Services.AuthServices
{
    public class AuthService : IAuthServices
    {
        private IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UsersDto usersDto)
        {
            var claims = new Claim[]
           {
                // name 
                new Claim("UserName", usersDto.UserName),
                // identificatori
                new Claim("Password",usersDto.Password),
                new Claim(ClaimTypes.Role,usersDto.Role),
                // vaqti
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),

           };

            // qandedur algoritm boyicha shifrlanadi
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
