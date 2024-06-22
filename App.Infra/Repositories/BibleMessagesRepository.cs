using App.Domain.Entities.TimeLine;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repositories
{
    public class BibleMessagesRepository : IBibleMessagesRepository
    {
        private readonly IbntDbContext _context;
        public BibleMessagesRepository(IbntDbContext context)
        {
            _context = context;
        }

        public async Task<BibleMessageEntity> Create(BibleMessageEntity newMessage)
        {
            await _context.BibleMessages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            var createdMessage = await _context.BibleMessages.FindAsync(newMessage.Id);
            return createdMessage!;
        }

        public async Task<List<BibleMessageEntity>> GetAllAsync() => await _context.BibleMessages.ToListAsync();

        public async Task<BibleMessageEntity> GetByIdAsync(Guid id)
        {
            var currentMessage = await _context.BibleMessages
                .IgnoreAutoIncludes()
                .Include(b => b.Reactions)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (currentMessage == null)
            {
                throw new BibleMessageException("Nenhuma mensagem com o id fornecido foi encontrada.");
            }
            return currentMessage;
        }

        public async Task<List<BibleMessageEntity>> GetMessagesByMemberIdAsync(Guid memberId)
        {
            var memberMessages = await _context.BibleMessages
                .Where(m => m.MemberId == memberId)
                .ToListAsync();
            if (memberMessages == null || !memberMessages.Any())
            {
                throw new BibleMessageException($"Nenhuma mensagem atribuída ao usuário com o id {memberId} foi encontrada.");
            }
            return memberMessages;
        }

        public async Task<BibleMessageEntity> Update(Guid id, BibleMessageEntity message)
        {
            var currentMessage = await _context.BibleMessages.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (currentMessage == null)
            {
                throw new BibleMessageException("Nenhuma mensagem com o id fornecido foi encontrada.");
            }
            currentMessage.ChangeTitle(message.Title);
            currentMessage.ChangeBaseText(message.BaseText);
            currentMessage.ChangeContent(message.Content);

            _context.BibleMessages.Update(currentMessage);
            await _context.SaveChangesAsync();
            return currentMessage;
        }

        public async Task Delete(Guid id)
        {
            var currentMessage = await _context.BibleMessages
                .IgnoreAutoIncludes()
                .Include(b => b.Reactions)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (currentMessage == null)
            {
                throw new BibleMessageException("Nenhuma mensagem com o id fornecido foi encontrada.");
            }
            _context.BibleMessages.Remove(currentMessage);
            await _context.SaveChangesAsync();
        }
    }
}
