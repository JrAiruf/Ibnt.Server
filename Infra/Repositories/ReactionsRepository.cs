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

        public async Task Create(ReactionEntity reaction)
        {
            _context.Reactions.AsNoTracking();
            await _context.Reactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReactionEntity>> GetAll()
        {
            return await _context.Reactions.ToListAsync();
        }

        public async Task<List<ReactionEntity>> GetReactionsByEventId(Guid eventId)
        {
            var reactions = await _context.Reactions
            .Where(reaction =>
            reaction.EventId == eventId)
            .ToListAsync();

            return reactions;
        }
    }
}
