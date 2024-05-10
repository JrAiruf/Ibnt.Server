using Ibnt.Domain.Entities.TimeLine;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Repositories
{
    public class BibleMessagesRepository : IBibleMessagesRepository
    {
        private readonly IbntDbContext _context;
        public BibleMessagesRepository(IbntDbContext context)
        {
            _context = context;
        }
        public async Task<BibleMessageEntity> Ceate(BibleMessageEntity newMessage)
        {
            await _context.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            var createdMessage = await _context.BibleMessages.FindAsync(newMessage.Id);
            return createdMessage!;
        }

        public async Task<List<BibleMessageEntity>> GetAllAsync() => await _context.BibleMessages.ToListAsync();
    }
}
