using Ibnt.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Dtos.BibleMessageEntity;

namespace Ibnt.Server.Application.Dtos.TimeLineEntity
{
    public record TimeLineDto
    {
        public string Title { get; init; }
        public Guid Id { get; init; }
        public List<EventListDto> Events { get; init; }
        public List<BibleMessageListDto> BibleMessages { get; init; } 
    }
}
