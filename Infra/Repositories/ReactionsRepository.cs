using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Repositories
{
    public class ReactionsRepository : IReactionsRepository
    {
        private readonly IbntDbContext _context;
        public ReactionsRepository(IbntDbContext context)
        {
            _context = context;
        }

        public async Task<ReactionEventEntity> Create(ReactionEventEntity newReaction)
        {
            await _context.EventReactions.AddAsync(newReaction);
            await _context.SaveChangesAsync();
            return newReaction;
        }

        public async Task<ReactionBibleMessageEntity> Create(ReactionBibleMessageEntity newReaction)
        {
            await _context.BibleMessageReactions.AddAsync(newReaction);
            await _context.SaveChangesAsync();
            return newReaction;
        }

        public async Task<ReactionPostEntity> Create(ReactionPostEntity newReaction)
        {
            await _context.PostReactions.AddAsync(newReaction);
            await _context.SaveChangesAsync();
            return newReaction;
        }

        public async Task<List<ReactionEventEntity>> GetAllEventsReactions() => 
        await _context.EventReactions.ToListAsync();

        public async Task<List<ReactionBibleMessageEntity>> GetAllBibleMessagesReactions() => 
        await _context.BibleMessageReactions.ToListAsync();

        public async Task<List<ReactionPostEntity>> GetAllPostsReactions() => 
        await _context.PostReactions.ToListAsync();

        public async Task<List<ReactionEventEntity>> GetReactionsByEventId(Guid eventId)
        {
            var reactions = await _context.EventReactions
            .Where(reaction =>
            reaction.EventId == eventId)
            .ToListAsync();

            return reactions;
        }

        public async Task<List<ReactionBibleMessageEntity>> GetReactionsByBibleMessageId(Guid messageId)
        {
            var reactions = await _context.BibleMessageReactions
            .Where(reaction =>
           reaction.BibleMessageId == messageId)
           .ToListAsync();

            return reactions;
        }

        public async Task<List<ReactionPostEntity>> GetReactionsByPostId(Guid postId)
        {
            var reactions = await _context.PostReactions
           .Where(reaction =>
           reaction.PostId == postId)
           .ToListAsync();

            return reactions;
        }
    }
}
