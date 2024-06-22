using App.Domain.Entities.Reactions;

namespace App.Application.Interfaces
{
    public interface IReactionsRepository
    {
        public Task Create(ReactionEventEntity newReaction);
        public Task Create(ReactionBibleMessageEntity newReaction);
        public Task Create(ReactionPostEntity newReaction);
        public Task Update(ReactionEventEntity reaction);
        public Task Update(ReactionBibleMessageEntity reaction);
        public Task Update(ReactionPostEntity reaction);
        public Task UntoggleReaction(Guid memberId, Guid itemId);
        public Task<List<ReactionEventEntity>> GetAllEventsReactions();
        public Task<List<ReactionBibleMessageEntity>> GetAllBibleMessagesReactions();
        public Task<List<ReactionPostEntity>> GetAllPostsReactions();
        public Task<List<ReactionEventEntity>> GetReactionsByEventId(Guid eventId);
        public Task<List<ReactionBibleMessageEntity>> GetReactionsByBibleMessageId(Guid messageId);
        public Task<List<ReactionPostEntity>> GetReactionsByPostId(Guid postId);
    }
}
