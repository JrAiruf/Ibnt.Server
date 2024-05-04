using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Users;
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
            if (_hashService.CompareValue(password, credential.Password))
            {
                var currentUser = await _context.Members.Where(m => m.Credential.Email == email).FirstOrDefaultAsync();
                credential.CHangeMemberId(currentUser.Id);
                return credential;
            }
            else
            {
                return null;
            }
        }
    }
}
