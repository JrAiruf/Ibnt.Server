using App.Application.Dtos.EventEntity;
using App.Application.Dtos.BibleMessageEntity;
using App.Application.Dtos.TimeLineEntity;
using App.Domain.Entities.TimeLine;

namespace App.Application.Extensions
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
