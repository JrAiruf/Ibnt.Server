using App.Domain.Entities.Users.Auth;
//using Microsoft.IdentityModel.Tokens;

namespace App.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(AuthCredentialEntity auth);
        public bool ValidateToken(string token);
    }
}
