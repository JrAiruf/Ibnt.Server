using App.Domain.Entities.Users.Auth;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repositories
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
            var registeredCredential = await _context.Credential
                .Where(c => c.Email == credential.Email)
                .FirstOrDefaultAsync();

            if (registeredCredential != null)
            {
                throw new ExistingUserException("E-mail já cadastrado. Utilize outro e-mail para criar sua conta.");
            }

            await _context.Credential.AddAsync(credential);
            await _context.SaveChangesAsync();
            return credential;
        }

        public async Task<IEnumerable<AuthCredentialEntity>> GetAll()
        {
            return await _context.Credential.ToListAsync();
        }

        public async Task<AuthCredentialEntity?> GetCredential(string email, string password)
        {

            var credential = await _context.Credential.FindAsync(email);
            if (credential == null)
            {
                throw new AuthCredentialEntityException("Erro ao realizar login. Verifique os dados e tente novamente");
            }
            if (_hashService.CompareValue(password, credential.Password))
            {
                var currentUser = await _context.Member.Where(m => m.Credential.Email == email).FirstOrDefaultAsync();
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
            var credential = await _context.Credential.FindAsync(email);
            if (credential == null)
            {
                throw new AuthCredentialEntityException("Não há nehum e-mail compatível registrado.");
            }
            var currentUser = await _context.Member.Where(m => m.Credential.Email == email).FirstOrDefaultAsync();
            var verificationCode = _hashService.GenerateVerificationCode(6);
            var provisoryPassword = _hashService.GenerateVerificationCode(8);
            var recoveryEntity = new RecoveryPasswordEntity(currentUser.FullName, verificationCode, credential.Email, provisoryPassword);
            await _context.RecoveryPassword.AddAsync(recoveryEntity);
            await _context.SaveChangesAsync();
            return recoveryEntity;
        }

        public async Task<RecoveryPasswordEntity> GetRecoveryPasswordEntityByVerificationCode(string verificationCode)
        {
            var currentRecoveryEntity = await _context.RecoveryPassword.FindAsync(verificationCode);
            if (currentRecoveryEntity == null)
            {
                throw new AuthCredentialEntityException("O código de verificação informado, não é válido.");
            }
            _context.RecoveryPassword.Remove(currentRecoveryEntity);
            await _context.SaveChangesAsync();
            return currentRecoveryEntity;
        }

        public async Task UpdateCredential(AuthCredentialEntity credential)
        {
            var currentCredential = await _context.Credential.FindAsync(credential.Email);
            currentCredential.ChangePassword(_hashService.HashValue(credential.Password));
            _context.Credential.Update(currentCredential);
            await _context.SaveChangesAsync();
        }
    }
}
