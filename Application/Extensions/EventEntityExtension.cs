using Ibnt.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Dtos.ReactionEntity;
using Ibnt.Server.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Extensions
{
    public static class EventEntityExtension
    {

        public static EventDto AsDto(this EventEntity? eventEntity)
        {
            return new EventDto
            {
                Id = eventEntity!.Id,
                Title = eventEntity.Title,
                ImageUrl = eventEntity.ImageUrl,
                PostDate = eventEntity.PostDate,
                Date = eventEntity.Date,
                Description = eventEntity.Description,
                Reactions = eventEntity.Reactions?.Select(r => r.AsDto()).ToList() ?? new List<EventReactionDto>()
            };
        }

        public static EventListDto AsListDto(this EventEntity eventEntity)
        {
            return new EventListDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                ImageUrl = eventEntity.ImageUrl,
                PostDate = eventEntity.PostDate,
                Date = eventEntity.Date,
                Description = eventEntity.Description,
            };
        }
    }
}
