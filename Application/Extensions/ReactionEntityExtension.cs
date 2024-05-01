using Ibnt.Server.Application.Dtos.GloryReactionEntity;
using Ibnt.Server.Domain.Entities.Reactions;

namespace Ibnt.Server.Application.Extensions
{
    public static class ReactionEntityExtension
    {
        public static ReactionDto AsDto(this ReactionEntity reaction)
        {
            return new ReactionDto
            {
                Name = reaction.Name,
                MemberId = reaction.MemberId,
                EventId = reaction.EventId,
                Toogled = reaction.Toogled,
            };
        }
    }
}
