using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Reactions
{
    public class ReactionEntity
    {
        public string Name { get; private set; }
        public Guid MemberId { get; private set; }
        public Guid EventId { get; private set; }
        public bool Toogled { get; private set; } = true;
        public MemberEntity? Member { get; set; }
        public EventEntity? Event { get; set; }
        public void ChangeName(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new TimeLineContentException("A propriedade name não pode ser vazia ou nula.");
            }
            Name = name;
        }

        public void ChangeMemberId(Guid? memberId)
        {
            if (!memberId.HasValue)
            {
                throw new TimeLineContentException("A propriedade memberId não pode ser vazia ou nula.");
            }
            MemberId = memberId.Value;
        }

        public void ChangeEventId(Guid? eventId)
        {
            if (eventId.HasValue)
            {
                throw new TimeLineContentException("A propriedade eventId não pode ser vazia ou nula.");
            }
            EventId = eventId.Value;
        }
    }
}

