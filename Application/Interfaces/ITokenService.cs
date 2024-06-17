using Ibnt.Server.Domain.Entities.Users.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Ibnt.Server.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(AuthCredentialEntity auth);
        public bool ValidateToken(string token);
    }
}
