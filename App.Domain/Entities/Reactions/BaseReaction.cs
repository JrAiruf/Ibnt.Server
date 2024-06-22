using App.Domain.Exceptions;

namespace App.Domain.Entities.Reactions
{
    public abstract class BaseReaction
    {
        public string Name { get; private set; }
        public bool Toogled { get; private set; } = true;
        public Guid MemberId { get; private set; }
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
    }
}
