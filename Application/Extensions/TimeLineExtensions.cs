using Ibnt.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Dtos.BibleMessageEntity;
using Ibnt.Server.Application.Dtos.TimeLineEntity;
using Ibnt.Server.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Extensions
{
    public static class TimeLineExtensions
    {
        public static TimeLineDto AsDto(this TimeLineEntity timeline)
        {
            return new TimeLineDto
            {
                Id = timeline.Id,
                Title = timeline.Title,
                Events = timeline?.Events?.Select(e => e.AsListDto()).ToList() ?? new List<EventListDto>(),
                BibleMessages = timeline?.BibleMessages?.Select(m => m.AsListDto()).ToList() ?? new List<BibleMessageListDto>()
            };
        }
    }
}
