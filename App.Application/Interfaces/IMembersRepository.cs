using App.Domain.Entities.Users;

namespace App.Application.Interfaces
{
    public interface IMembersRepository
    {
        public Task<MemberEntity> Create(MemberEntity member);
        public Task<IEnumerable<MemberEntity>> GetAll();
        public Task<MemberEntity> GetById(Guid id);
    }
}
