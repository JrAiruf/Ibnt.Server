using Ibnt.Server.Domain.Entities.Reactions;

namespace Ibnt.Server.Application.Interfaces
{
    public interface IReactionsRepository
    {
        public Task Create(ReactionEntity newReaction);
        public Task<List<ReactionEntity>> GetAll();
        public Task<List<ReactionEntity>> GetReactionsByEventId(Guid eventId);
    }
}
