using App.Domain.Entities.TimeLine;
using App.Application.Dtos.BibleMessageEntity;
using App.Application.Dtos.ReactionEntity;

namespace App.Application.Extensions
{
    public static class BibleMessageExtension
    {
        public static BibleMessageDto AsDto (this BibleMessageEntity entity)
        {
            return new BibleMessageDto
            {
                Id = entity.Id,
                Title= entity.Title,
                BaseText = entity.BaseText,
                Type = entity.Type,
                Content = entity.Content,
                CreationDate = entity.CreationDate,
                PostDate = entity.PostDate,
                EntityType = entity.EntityType,
                Reactions = entity.Reactions?.Select(r => r.AsDto()).ToList() ?? new List<BibleMessageReactionDto>(),
                MemberId = entity.MemberId
            };
        }

        public static BibleMessageListDto AsListDto (this BibleMessageEntity entity)
        {
            return new BibleMessageListDto
            {
                Id = entity.Id,
                Title = entity.Title,
                BaseText = entity.BaseText,
                Type = entity.Type,
                Content = entity.Content,
                CreationDate = entity.CreationDate,
                PostDate = entity.PostDate,
                EntityType = entity.EntityType,
                Member = entity.Member.AsDtoList(),
            };
        }
    }
}
