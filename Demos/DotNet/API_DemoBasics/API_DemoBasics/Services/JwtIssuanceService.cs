using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace API_DemoBasics.Services
{
    public class JwtIssuanceService
    {
        private readonly IConfiguration _configuration;

        public JwtIssuanceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userName, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, userName)
            };
            roles.ForEach(role => 
            { 
                claims.Add(new Claim(ClaimTypes.Role, role));
            });
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryInMinutes"]!)),
                signingCredentials: creds
                );
            return tokenHandler.WriteToken(token);
        }
    }
}
