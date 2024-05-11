using Ibnt.Server.Application.Dtos.ReactionEntity;
using Ibnt.Server.Domain.Entities.Reactions;

namespace Ibnt.Server.Application.Extensions
{
    public static class ReactionExtension
    {
        public static EventReactionDto AsDto(this ReactionEventEntity reaction)
        {
            return new EventReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toogled = reaction.Toogled,
            };
        }
        public static BibleMessageReactionDto AsDto(this ReactionBibleMessageEntity reaction)
        {
            return new BibleMessageReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toogled = reaction.Toogled
            };
        }
        public static PostReactionDto AsDto(this ReactionPostEntity reaction)
        {
            return new PostReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                Toogled = reaction.Toogled,
            };
        }
    }
}
