using App.Domain.Entities.Reactions;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repositories
{
    public class ReactionsRepository : IReactionsRepository
    {
        private readonly IbntDbContext _context;
        public ReactionsRepository(IbntDbContext context)
        {
            _context = context;
        }

        public async Task Create(ReactionEventEntity newReaction)
        {
            await _context.EventReaction.AddAsync(newReaction);
            await _context.SaveChangesAsync();
        }

        public async Task Create(ReactionBibleMessageEntity newReaction)
        {
            await _context.BibleMessageReaction.AddAsync(newReaction);
            await _context.SaveChangesAsync();
        }

        public async Task Create(ReactionPostEntity newReaction)
        {
            await _context.PostReaction.AddAsync(newReaction);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ReactionEventEntity reaction)
        {
            var currentEventReaction = await _context.EventReaction
               .FirstOrDefaultAsync(eR =>
               eR.MemberId == reaction.MemberId &&
               eR.EventId == reaction.EventId);

            currentEventReaction?.ChangeName(reaction.Name);
            if (currentEventReaction != null)
            {
                _context.EventReaction.Update(currentEventReaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task Update(ReactionBibleMessageEntity reaction)
        {
            var currentBibleMessageReaction = await _context.BibleMessageReaction
            .FirstOrDefaultAsync(eR =>
            eR.MemberId == reaction.MemberId &&
            eR.BibleMessageId == reaction.BibleMessageId);

            currentBibleMessageReaction?.ChangeName(reaction.Name);
            if (currentBibleMessageReaction != null)
            {
                _context.BibleMessageReaction.Update(currentBibleMessageReaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task Update(ReactionPostEntity reaction)
        {
            var currentPostReaction = await _context.PostReaction
           .FirstOrDefaultAsync(eR =>
           eR.MemberId == reaction.MemberId &&
           eR.PostId == reaction.PostId);

            currentPostReaction?.ChangeName(reaction.Name);
            if (currentPostReaction != null)
            {
                _context.PostReaction.Update(currentPostReaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException("Não foi possível modificar o estado da reação atual.");
            }
        }

        public async Task UntoggleReaction(Guid memberId, Guid itemId)
        {

            bool isEventEntity = _context.EventReaction
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.EventId == itemId).ToList().Any();

            if (isEventEntity)
            {
                var currentEventReaction = await _context.EventReaction
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.EventId == itemId);
                _context.EventReaction.Remove(currentEventReaction);
                await _context.SaveChangesAsync();
                return;
            }

            bool isBibleMessageEntity = _context.BibleMessageReaction
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.BibleMessageId == itemId).ToList().Any();

            if (isBibleMessageEntity)
            {
                var currentBibleMessageReaction = await _context.BibleMessageReaction
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.BibleMessageId == itemId);
                _context.BibleMessageReaction.Remove(currentBibleMessageReaction);
                await _context.SaveChangesAsync();
                return;
            }

            bool isPostEntity = _context.PostReaction
                .Where(eR =>
                eR.MemberId == memberId &&
                eR.PostId == itemId).ToList().Any();

            if (isPostEntity)
            {
                var currentPostReaction = await _context.PostReaction
                .FirstOrDefaultAsync(eR =>
                eR.MemberId == memberId &&
                eR.PostId == itemId);
                _context.PostReaction.Remove(currentPostReaction);
                await _context.SaveChangesAsync();
                return;
            }
        }

        public async Task<List<ReactionEventEntity>> GetAllEventsReactions() =>
        await _context.EventReaction.Where(eR => eR.Toogled == true).ToListAsync();

        public async Task<List<ReactionBibleMessageEntity>> GetAllBibleMessagesReactions() =>
        await _context.BibleMessageReaction.Where(bM => bM.Toogled == true).ToListAsync();

        public async Task<List<ReactionPostEntity>> GetAllPostsReactions() =>
        await _context.PostReaction.Where(p => p.Toogled == true).ToListAsync();

        public async Task<List<ReactionEventEntity>> GetReactionsByEventId(Guid eventId)
        {
            var reactions = await _context.EventReaction
            .Where(reaction =>
            reaction.EventId == eventId)
            .ToListAsync();

            return reactions;
        }

        public async Task<List<ReactionBibleMessageEntity>> GetReactionsByBibleMessageId(Guid messageId)
        {
            var reactions = await _context.BibleMessageReaction
            .Where(reaction =>
           reaction.BibleMessageId == messageId)
           .ToListAsync();

            return reactions;
        }

        public async Task<List<ReactionPostEntity>> GetReactionsByPostId(Guid postId)
        {
            var reactions = await _context.PostReaction
           .Where(reaction =>
           reaction.PostId == postId)
           .ToListAsync();

            return reactions;
        }
    }
}
