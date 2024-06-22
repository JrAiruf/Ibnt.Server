using App.Application.Dtos.EventEntity;
using App.Application.Dtos.EventEntity;
using App.Application.Dtos.ReactionEntity;
using App.Domain.Entities.TimeLine;

namespace App.Application.Extensions
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
                EntityType = eventEntity.EntityType,
                Description = eventEntity.Description
            };
        }
    }
}
