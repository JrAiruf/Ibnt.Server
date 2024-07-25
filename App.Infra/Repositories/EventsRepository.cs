using App.Domain.Entities.TimeLine;
using App.Application.Interfaces;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IbntDbContext _context;
        public EventsRepository(IbntDbContext context)
        {
            _context = context;
        }
        public async Task<EventEntity> Create(EventEntity newEvent)
        {
            await _context.Event.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<IEnumerable<EventEntity>> GetAll()
        {
            var eventsList = await _context.Event.IgnoreAutoIncludes().ToListAsync();
            return eventsList;
        }

        public async Task<EventEntity?> GetById(Guid id)
        {
            var currentEvent = await _context.Event
                .Include(e => e.Reactions)
                .FirstOrDefaultAsync(e => e.Id == id);
            return currentEvent;
        }

        public async Task<EventEntity> Update(Guid id, EventEntity eventToUpdate)
        {
            var currentEvent = await GetById(id);
            if(currentEvent != null)
            {
                _context.Event.Update(currentEvent);
                await _context.SaveChangesAsync();

                return currentEvent;
            } else
            {
                return null!;
            }
        }

        public async Task Delete(Guid id)
        {
            var currentEvent = await GetById(id);
            _context.Event.Remove(currentEvent);
            await _context.SaveChangesAsync();
        }
    }
}
