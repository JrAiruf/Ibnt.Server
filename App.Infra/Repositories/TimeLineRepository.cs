using App.Application.Interfaces;
using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

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
            TimeLineEntity? timeline = await _context.TimeLine.FirstOrDefaultAsync();
            if (timeline == null)
            {
                throw new TimeLineContentException("No data found.");
            }

            List<EventEntity> timelineEvents = await _context.Event.Where(e => e.TimeLineId == timeline!.Id)
                                                                   .OrderBy(e => e.PostDate)
                                                                   .ToListAsync();
            List<BibleMessageEntity> bibleMessages = await _context.BibleMessage
                                                                   .Include(b => b.Member)
                                                                   .Where(b => b.TimeLineId == timeline!.Id)
                                                                   .OrderBy(e => e.PostDate)
                                                                   .ToListAsync();
            timeline.BibleMessages = bibleMessages;
            timeline.Events = timelineEvents;

            return timeline;
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
                _ = (timeline?.Events?.Remove(currentEvent));
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
            BibleMessageEntity? currentBibleMessage = await _context.BibleMessage.FindAsync(messageId);
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
