using Grpc.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_DemoGRPC;

namespace API_DemoGRPC.Services
{
    public class Auth : AuthService.AuthServiceBase
    {
        private string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "Zensar",
                Audience = "ZensarAudience",
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); ;
        }

        public override Task<TokenReply> GetToken(TokenRequest request, ServerCallContext context)
        {
            var token = GenerateToken(request.UserName);
            return Task.FromResult(new TokenReply() { Token = token });
        }
    }
}
