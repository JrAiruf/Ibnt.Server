using App.Domain.Entities.Users.Auth;
using App.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Infra.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(AuthCredentialEntity auth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(Secrets.SecretKey!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
             {
                new Claim(ClaimTypes.PrimarySid,auth.MemberId.ToString()!),
                new Claim(ClaimTypes.Email,auth.Email),
                new Claim(ClaimTypes.Role,auth.Role),
             }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var currentToken = tokenHandler.ReadToken(token);
            bool validToken = DateTime.UtcNow.CompareTo(currentToken.ValidTo) <= 0;
            return validToken;
        }
    }
}
