using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Domain.Entities.TimeLine
{
    public class BibleMessageEntity : TimeLineContent
    {

        public BibleMessageEntity(string title, string baseText, string content, Guid memberId)
        {
            ChangeTitle(title);
            ChangeBaseText(baseText);
            ChangeContent(content);
            ChangeMemberId(memberId);
        }
        public string? BaseText { get; set; }
        public string EntityType { get; private set; } = "message";
        public List<ReactionEntity>? Reactions { get; set; }
        public Guid MemberId { get; set; }
        public MemberEntity? Member { get; set; }

        public void ChangeBaseText(string? baseText)
        {
            if (string.IsNullOrEmpty(baseText))
            {
                throw new TimeLineContentException("A propriedade baseText não pode ser vazia ou nula.");
            }
            BaseText = baseText;
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