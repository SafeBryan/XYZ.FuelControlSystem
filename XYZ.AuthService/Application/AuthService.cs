using XYZ.AuthService.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace XYZ.AuthService.Application
{
    public class AuthService
    {
        private readonly IConfiguration _config;

        private readonly List<User> _users = new()
        {
            new User { Username = "admin", Password = "1234", Rol = Rol.ADMIN }
        };

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public (bool success, string token, Rol? rol) Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
                return (false, "", null);

            var token = GenerateJwtToken(user);
            return (true, token, user.Rol);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Rol.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
