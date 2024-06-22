using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;

namespace App.Domain.Entities.Reactions
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

