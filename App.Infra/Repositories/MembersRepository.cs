using App.Domain.Entities.Users;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;
using App.Application.Dtos.MemberEntity;
using Microsoft.TeamFoundation.Work.WebApi;

namespace App.Infra.Repositories
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
            var registeredCredential = await _context.Credential
              .Where(c => c.Email == member.Credential!.Email)
              .FirstOrDefaultAsync();
            if (registeredCredential != null)
            {
                throw new ExistingUserException("E-mail já cadastrado. Utilize outro e-mail para criar sua conta.");
            }
            await _context.Member.AddAsync(member);
            await _context.Credential.AddAsync(member.Credential!);
            await _context.SaveChangesAsync();

            var createdMember = await _context.Member
               .IgnoreAutoIncludes()
               .Include(m => m.Credential)
               .FirstOrDefaultAsync(m => m.Id == member.Id);

            return createdMember;
        }

        public async Task<IEnumerable<MemberEntity>> GetAll() => await _context.Member.IgnoreAutoIncludes().ToListAsync();

        public async Task<MemberEntity> GetById(Guid id)
        {
            var currentMember = await _context.Member
                .IgnoreAutoIncludes()
                .Include(m => m.Credential)
                .Include(m => m.BibleMessages)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (currentMember != null)
            {
                return currentMember;
            }
            else
            {
                return null!;
            }
        }

        public async Task<MemberEntity> UpdateAsync(Guid id, MemberEntity member)
        {
            MemberEntity currentMember = await _context.Member.FindAsync(id);
            currentMember?.ChangeFullName(member.FullName);
            currentMember?.ChangeProfileImage(member.ProfileImage);

            _context.Update(currentMember);
            await _context.SaveChangesAsync();

            return currentMember;
        }
    }
}
