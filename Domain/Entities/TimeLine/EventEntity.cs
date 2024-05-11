using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.TimeLine
{
    public class EventEntity : TimeLineContent
    {
        public EventEntity(string title, DateTime? postDate, DateTime? date, string description, string imageUrl)
        {
            ChangeTitle(title);
            ChangePostDate(postDate);
            ChangeDate(date);
            ChangeDescription(description);
            ChangeImageUrl(imageUrl);
        }
        public EventEntity() { }
        public string? ImageUrl { get; private set; }
        public string Description { get; private set; }
        public string EntityType { get; private set; } = "event";
        public List<ReactionEventEntity>? Reactions { get; set; }
        public MemberEntity? Member { get; set; }

        public void ChangeImageUrl(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new EventException("A propriedade imageUrl não pode ser vazia ou nula.");
            }
            ImageUrl = imageUrl;
        }
        public void ChangeDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new EventException("A propriedade description não pode ser vazia ou nula.");
            }
            Description = description;
        }
    }
}
