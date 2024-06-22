using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;

namespace App.Domain.Entities.Reactions
{
    public class ReactionBibleMessageEntity : BaseReaction
    {
        public Guid BibleMessageId { get; private set; }
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
