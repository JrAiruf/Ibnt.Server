using App.Domain.Entities.Reactions;
using App.Domain.Entities.Users;
using App.Domain.Exceptions;

namespace App.Domain.Entities.TimeLine
{
    public class BibleMessageEntity : TimeLineContent
    {

        public BibleMessageEntity(string title, string baseText, string type, string content, Guid memberId)
        {
            ChangeTitle(title);
            ChangeBaseText(baseText);
            ChangeType(type);
            ChangeContent(content);
            ChangeMemberId(memberId);
        }
        public BibleMessageEntity(string title, string baseText, string content)
        {
            ChangeTitle(title);
            ChangeBaseText(baseText);
            ChangeContent(content);
        }
        public string? BaseText { get; set; }
        public string EntityType { get; private set; } = "message";
        public string Type { get; private set; }
        public List<ReactionBibleMessageEntity>? Reactions { get; set; }
        public Guid MemberId { get; set; }
        public MemberEntity? Member { get; set; }
        public TimeLineEntity? TimeLine { get; private set; }
        public Guid? TimeLineId { get; set; }

        public void ChangeBaseText(string? baseText)
        {
            if (string.IsNullOrEmpty(baseText))
            {
                throw new TimeLineContentException("A propriedade baseText não pode ser vazia ou nula.");
            }
            BaseText = baseText;
        }
        public void ChangeType(string? type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new TimeLineContentException("A propriedade type não pode ser vazia ou nula.");
            }
            Type = type;
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