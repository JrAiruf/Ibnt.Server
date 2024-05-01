using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Server.Application.Interfaces
{
    public interface IAuthRepository
    {
        public Task<AuthCredentialEntity> Create(AuthCredentialEntity credential);
        public Task<IEnumerable<AuthCredentialEntity>> GetAll();
        public Task<AuthCredentialEntity> GetCredential(string email, string password);
    }
}
