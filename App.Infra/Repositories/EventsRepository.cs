﻿using App.Domain.Entities.TimeLine;
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
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            var createdEvent = await _context.Events
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync(e => e.Id == newEvent.Id);
            return createdEvent!;
        }

        public async Task<IEnumerable<EventEntity>> GetAll()
        {
            var eventsList = await _context.Events.IgnoreAutoIncludes().ToListAsync();
            return eventsList;
        }

        public async Task<EventEntity?> GetById(Guid id)
        {
            var currentEvent = await _context.Events
                .Include(e => e.Reactions)
                .FirstOrDefaultAsync(e => e.Id == id);
            return currentEvent;
        }

        public Task<EventEntity> Update(Guid id, EventEntity eventToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var currentEvent = await GetById(id);
            _context.Events.Remove(currentEvent);
            await _context.SaveChangesAsync();
        }
    }
}