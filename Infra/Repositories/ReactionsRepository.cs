using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Exceptions;
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

        public async Task<ReactionEventEntity> Update(ReactionEventEntity reaction)
        {
            var currentEventReaction = await _context.EventReactions
               .FirstOrDefaultAsync(eR =>
               eR.MemberId == reaction.MemberId &&
               eR.EventId == reaction.EventId);

            currentEventReaction?.ChangeName(reaction.Name);
            if (currentEventReaction != null)
            {
                _context.EventReactions.Update(currentEventReaction);
                await _context.SaveChangesAsync();
                return currentEventReaction;
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task<ReactionBibleMessageEntity> Update(ReactionBibleMessageEntity reaction)
        {
            var currentBibleMessageReaction = await _context.BibleMessageReactions
            .FirstOrDefaultAsync(eR =>
            eR.MemberId == reaction.MemberId &&
            eR.BibleMessageId == reaction.BibleMessageId);

            currentBibleMessageReaction?.ChangeName(reaction.Name);
            if (currentBibleMessageReaction != null)
            {
                _context.BibleMessageReactions.Update(currentBibleMessageReaction);
                await _context.SaveChangesAsync();
                return currentBibleMessageReaction;
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task<ReactionPostEntity> Update(ReactionPostEntity reaction)
        {
            var currentPostReaction = await _context.PostReactions
           .FirstOrDefaultAsync(eR =>
           eR.MemberId == reaction.MemberId &&
           eR.PostId == reaction.PostId);

            currentPostReaction?.ChangeName(reaction.Name);
            if (currentPostReaction != null)
            {
                _context.PostReactions.Update(currentPostReaction);
                await _context.SaveChangesAsync();
                return currentPostReaction;
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task UntoggleReaction(Guid memberId, Guid itemId)
        {

            bool isEventEntity = _context.EventReactions
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.EventId == itemId).ToList().Any();

            if (isEventEntity)
            {
                var currentEventReaction = await _context.EventReactions
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.EventId == itemId);
                _context.EventReactions.Remove(currentEventReaction);
                await _context.SaveChangesAsync();
                return;
            }

            bool isBibleMessageEntity = _context.BibleMessageReactions
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.BibleMessageId == itemId).ToList().Any();

            if (isBibleMessageEntity)
            {
                var currentBibleMessageReaction = await _context.BibleMessageReactions
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.BibleMessageId == itemId);
                _context.BibleMessageReactions.Remove(currentBibleMessageReaction);
                await _context.SaveChangesAsync();
                return;
            }

            bool isPostEntity = _context.PostReactions
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.PostId == itemId).ToList().Any();

            if (isPostEntity)
            {
                var currentPostReaction = await _context.PostReactions
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.PostId == itemId);
                _context.PostReactions.Remove(currentPostReaction);
                await _context.SaveChangesAsync();
                return;
            }
        }

        public async Task<List<ReactionEventEntity>> GetAllEventsReactions() =>
        await _context.EventReactions.Where(eR => eR.Toogled == true).ToListAsync();

        public async Task<List<ReactionBibleMessageEntity>> GetAllBibleMessagesReactions() =>
        await _context.BibleMessageReactions.Where(bM => bM.Toogled == true).ToListAsync();

        public async Task<List<ReactionPostEntity>> GetAllPostsReactions() =>
        await _context.PostReactions.Where(p => p.Toogled == true).ToListAsync();

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
