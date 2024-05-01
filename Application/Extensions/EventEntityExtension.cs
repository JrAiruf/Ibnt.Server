using Ibnt.Server.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Dtos.GloryReactionEntity;
using Ibnt.Server.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Extensions
{
    public static class EventEntityExtension
    {

        public static EventDto AsDto(this EventEntity? eventEntity)
        {
            var eventDto = new EventDto
            {
                Id = eventEntity!.Id,
                Title = eventEntity.Title,
                ImageUrl = eventEntity.ImageUrl,
                PostDate = eventEntity.PostDate,
                Date = eventEntity.Date,
                Description = eventEntity.Description,
                Reactions = new List<ReactionDto>()
            };
            if(eventEntity.Reactions.Any())
            {
                eventDto.Reactions = eventEntity.Reactions.Select(r => r.AsDto()).ToList();
            }
            return eventDto;

    }
    public static EventDto AsListDto(this EventEntity eventEntity)
    {
        return new EventDto
        {
            Id = eventEntity.Id,
            Title = eventEntity.Title,
            ImageUrl = eventEntity.ImageUrl,
            PostDate = eventEntity.PostDate,
            Date = eventEntity.Date,
            Description = eventEntity.Description,
            Reactions = new List<ReactionDto>()
        };
    }
}
}
