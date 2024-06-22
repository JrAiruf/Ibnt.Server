using App.Domain.Entities.Users.Auth;

namespace App.Application.Interfaces
{
    public interface IAuthRepository
    {
        public Task<AuthCredentialEntity> Create(AuthCredentialEntity credential);
        public Task<IEnumerable<AuthCredentialEntity>> GetAll();
        public Task<AuthCredentialEntity> GetCredential(string email, string password);
        public Task<RecoveryPasswordEntity> GetCredentialByEmail(string email);
        public Task<RecoveryPasswordEntity> GetRecoveryPasswordEntityByVerificationCode(string verificationCode);
        public Task UpdateCredential(AuthCredentialEntity credential);
    }
}
