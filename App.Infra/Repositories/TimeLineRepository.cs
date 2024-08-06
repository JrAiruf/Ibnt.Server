using App.Application.Interfaces;
using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infra.Repositories
{
    public class TimeLineRepository : ITimeLineRepository
    {
        private readonly IbntDbContext _context;
        public TimeLineRepository(IbntDbContext context)
        {
            _context = context;
        }
        public async Task<TimeLineEntity> StartTimeLine()
        {
            TimeLineEntity timeline = new();
            _ = await _context.TimeLine.AddAsync(timeline);
            _ = await _context.SaveChangesAsync();
            return timeline;
        }
        public async Task<TimeLineEntity> GetTimeLineAsync()
        {
            TimeLineEntity? timeline = await _context.TimeLine
                .Include(t => t.Events.OrderByDescending(e => e.PostDate))
                .Include(t => t.BibleMessages.OrderByDescending(m => m.PostDate))
                .FirstOrDefaultAsync();
            return timeline == null ? throw new TimeLineContentException("No data found.") : timeline;
        }

        public async Task PostEvent(Guid eventId)
        {
            TimeLineEntity? timeline = await GetTimeLineAsync();
            EventEntity? currentEvent = await _context.Event.FindAsync(eventId);
            if (currentEvent != null)
            {
                bool alreadyInTimeine = timeline.Events
                    .Where(m => m.Id == currentEvent.Id)
                    .ToList()
                    .Any();

                if (alreadyInTimeine)
                {
                    throw new TimeLineContentException($"Event {eventId} Already Posted.");
                }
                currentEvent.PostDate = DateTime.UtcNow;
                timeline?.Events?.Add(currentEvent);
                _ = _context.TimeLine.Update(timeline);
                _ = await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException($"Event {eventId} Not Found.");
            }
        }

        public async Task RemoveEvent(Guid eventId)
        {
            TimeLineEntity? timeline = await GetTimeLineAsync();
            EventEntity? currentEvent = await _context.Event.FindAsync(eventId);
            if (currentEvent != null)
            {
                bool presentInTimeine = timeline.Events
                    .Where(m => m.Id == currentEvent.Id)
                    .ToList()
                    .Any();

                if (!presentInTimeine)
                {
                    throw new TimeLineContentException($"Event {eventId} removed.");
                }
                currentEvent.PostDate = DateTime.UtcNow;
                timeline?.Events?.Remove(currentEvent);
                _ = _context.TimeLine.Update(timeline);
                _ = await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException($"Event {eventId} Not Found.");
            }
        }

        public async Task PostBibleMessage(Guid messageId)
        {
            TimeLineEntity? timeline = await GetTimeLineAsync();
            var currentBibleMessage = await _context.BibleMessage.FindAsync(messageId);
            if (currentBibleMessage != null)
            {
                bool alreadyInTimeine = timeline.BibleMessages
                    .Where(m => m.Id == currentBibleMessage.Id)
                    .ToList()
                    .Any();

                if (alreadyInTimeine)
                {
                    throw new TimeLineContentException("Bible Message Already Posted.");
                }
                currentBibleMessage.PostDate = DateTime.UtcNow;
                timeline?.BibleMessages?.Add(currentBibleMessage);
                _ = _context.TimeLine.Update(timeline);
                _ = await _context.SaveChangesAsync();
            }
            else
            {
                throw new TimeLineContentException("Bible Message Not Saved.");
            }
        }
    }
}
