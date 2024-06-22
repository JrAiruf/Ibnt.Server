using App.Application.Dtos.ReactionEntity;
using App.Domain.Entities.Reactions;

namespace App.Application.Extensions
{
    public static class ReactionExtension
    {
        public static EventReactionDto AsDto(this ReactionEventEntity reaction)
        {
            return new EventReactionDto
            {
                EventId = reaction.EventId,
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled,
            };
        }
        
        public static EventReactionDto AsListDto(this ReactionEventEntity reaction)
        {
            return new EventReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled,
            };
        }

        public static BibleMessageReactionDto AsDto(this ReactionBibleMessageEntity reaction)
        {
            return new BibleMessageReactionDto
            {
                BibleMessageId = reaction.BibleMessageId,
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled
            };
        }

        public static BibleMessageReactionDto AsListDto(this ReactionBibleMessageEntity reaction)
        {
            return new BibleMessageReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled
            };
        }

        public static PostReactionDto AsDto(this ReactionPostEntity reaction)
        {
            return new PostReactionDto
            {
                PostId = reaction.PostId,
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled,
            };
        }

        public static PostReactionDto AsListDto(this ReactionPostEntity reaction)
        {
            return new PostReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toggled = reaction.Toogled,
            };
        }
    }
}
