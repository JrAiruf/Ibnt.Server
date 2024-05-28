using Ibnt.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Interfaces
{
    public interface IBibleMessagesRepository
    {
        public Task<BibleMessageEntity> Create(BibleMessageEntity newMessage);
        public Task<List<BibleMessageEntity>> GetAllAsync();
        public Task<List<BibleMessageEntity>> GetMessagesByMemberIdAsync(Guid memberId);
        public Task<BibleMessageEntity> GetByIdAsync(Guid id);
        public Task<BibleMessageEntity> Update(Guid id, BibleMessageEntity message);
        public Task Delete(Guid id);
    }
}
