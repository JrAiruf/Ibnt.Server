using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Reactions
{
    public class ReactionEventEntity : BaseReaction
    {
        public Guid EventId { get; private set; }
        public EventEntity? Event { get; private set; }


        public void ChangeEventId(Guid? eventId)
        {
            if (!eventId.HasValue)
            {
                throw new TimeLineContentException("A propriedade eventId não pode ser vazia ou nula.");
            }
            EventId = eventId.Value;
        }
    }
}

