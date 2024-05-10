using Ibnt.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Interfaces
{
    public interface IBibleMessagesRepository
    {
        public Task<BibleMessageEntity> Ceate(BibleMessageEntity newMessage);
        public Task<List<BibleMessageEntity>> GetAllAsync();
    }
}
