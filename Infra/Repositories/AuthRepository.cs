using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Users.Auth;
using Ibnt.Server.Domain.Exceptions;
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IbntDbContext _context;
        private readonly IHashService _hashService;
        public AuthRepository(IbntDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<AuthCredentialEntity> Create(AuthCredentialEntity credential)
        {
            var registeredCredential = await _context.Credentials
                .Where(c => c.Email == credential.Email)
                .FirstOrDefaultAsync();

            if (registeredCredential != null)
            {
                throw new ExistingUserException("E-mail já cadastrado. Utilize outro e-mail para criar sua conta.");
            }

            await _context.Credentials.AddAsync(credential);
            await _context.SaveChangesAsync();
            return credential;
        }

        public async Task<IEnumerable<AuthCredentialEntity>> GetAll()
        {
            return await _context.Credentials.ToListAsync();
        }

        public async Task<AuthCredentialEntity?> GetCredential(string email, string password)
        {

            var credential = await _context.Credentials.FindAsync(email);
            if (credential == null)
            {
                throw new AuthCredentialEntityException("Error ao realizar login. Verifique os dados e tente novamente");
            }
            if (_hashService.CompareValue(password, credential.Password))
            {
                var currentUser = await _context.Members.Where(m => m.Credential.Email == email).FirstOrDefaultAsync();
                credential.ChangeMemberId(currentUser.Id);
                return credential;
            }
            else
            {
                return null;
            }
        }
        public async Task<RecoveryPasswordEntity?> GetCredentialByEmail(string email)
        {
            var credential = await _context.Credentials.FindAsync(email);
            if (credential == null)
            {
                throw new AuthCredentialEntityException("Não há nehum e-mail compatível registrado.");
            }
            var currentUser = await _context.Members.Where(m => m.Credential.Email == email).FirstOrDefaultAsync();
            var verificationCode = _hashService.GenerateVerificationCode(6);
            var provisoryPassword = _hashService.GenerateVerificationCode(8);
            var recoveryEntity = new RecoveryPasswordEntity(currentUser.FullName, verificationCode, credential.Email, provisoryPassword);
            await _context.RecoveryPasswords.AddAsync(recoveryEntity);
            await _context.SaveChangesAsync();
            return recoveryEntity;
        }

        public async Task<RecoveryPasswordEntity> GetRecoveryPasswordEntityByVerificationCode(string verificationCode)
        {
            var currentRecoveryEntity = await _context.RecoveryPasswords.FindAsync(verificationCode);
            if (currentRecoveryEntity == null)
            {
                throw new AuthCredentialEntityException("O código de verificação informado, não é válido.");
            }
            _context.RecoveryPasswords.Remove(currentRecoveryEntity);
            await _context.SaveChangesAsync();
            return currentRecoveryEntity;
        }

        public async Task UpdateCredential(AuthCredentialEntity credential)
        {
            var currentCredential = await _context.Credentials.FindAsync(credential.Email);
            currentCredential.ChangePassword(_hashService.HashValue(credential.Password));
            _context.Credentials.Update(currentCredential);
            await _context.SaveChangesAsync();
        }
    }
}
