using Ibnt.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Reactions
{
    public class ReactionBibleMessageEntity : BaseReaction
    {
        public Guid BibleMessageId { get; private set; }
        public bool Toogled { get; private set; } = true;
        public BibleMessageEntity? BibleMessage { get; private set; }


        public void ChangeBibleMessageId(Guid? bibleMessageId)
        {
            if (!bibleMessageId.HasValue)
            {
                throw new TimeLineContentException("A propriedade bibleMessageId não pode ser vazia ou nula.");
            }
            BibleMessageId = bibleMessageId.Value;
        }
    }
}
