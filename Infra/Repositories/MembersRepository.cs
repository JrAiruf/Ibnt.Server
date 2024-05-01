using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Exceptions;
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly IbntDbContext _context;
        public MembersRepository(IbntDbContext context)
        {
            _context = context;
        }
        public async Task<MemberEntity> Create(MemberEntity member)
        {
            var registeredCredential = await _context.Credentials
              .Where(c => c.Email == member.Credential.Email)
              .FirstOrDefaultAsync();
            if (registeredCredential != null)
            {
                throw new ExistingUserException("E-mail já cadastrado. Utilize outro e-mail para criar sua conta.");
            }
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            var createdMember = await _context.Members.FindAsync(member.Id);
            return createdMember;
        }

        public async Task<IEnumerable<MemberEntity>> GetAll()
        {
            return await _context.Members
                .Include(
                c => c.Credential
                ).ToListAsync();
        }

        public async Task<MemberEntity> GetById(Guid id)
        {
            var currentMember = await _context.Members.FindAsync(id);
            return currentMember;
        }
    }
}
