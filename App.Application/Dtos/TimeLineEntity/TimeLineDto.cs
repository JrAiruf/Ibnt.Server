using App.Application.Dtos.EventEntity;
using App.Application.Dtos.BibleMessageEntity;

namespace App.Application.Dtos.TimeLineEntity
{
    public record TimeLineDto
    {
        public string Title { get; init; }
        public Guid Id { get; init; }
        public List<EventListDto> Events { get; init; }
        public List<BibleMessageListDto> BibleMessages { get; init; } 
    }
}
