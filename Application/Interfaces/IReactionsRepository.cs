﻿using Ibnt.Server.Domain.Entities.Reactions;

namespace Ibnt.Server.Application.Interfaces
{
    public interface IReactionsRepository
    {
        public Task<ReactionEventEntity> Create(ReactionEventEntity newReaction);
        public Task<ReactionBibleMessageEntity> Create(ReactionBibleMessageEntity newReaction);
        public Task<ReactionPostEntity> Create(ReactionPostEntity newReaction);
        public Task<List<ReactionEventEntity>> GetAllEventsReactions();
        public Task<List<ReactionBibleMessageEntity>> GetAllBibleMessagesReactions();
        public Task<List<ReactionPostEntity>> GetAllPostsReactions();
        public Task<List<ReactionEventEntity>> GetReactionsByEventId(Guid eventId);
        public Task<List<ReactionBibleMessageEntity>> GetReactionsByBibleMessageId(Guid messageId);
        public Task<List<ReactionPostEntity>> GetReactionsByPostId(Guid postId);
    }
}
