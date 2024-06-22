using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;

namespace App.Domain.Entities.Reactions
{
    public class ReactionPostEntity : BaseReaction
    {
        public Guid PostId { get; private set; }
        public PostEntity? Post { get; private set; }


        public void ChangePostId(Guid? postId)
        {
            if (!postId.HasValue)
            {
                throw new TimeLineContentException("A propriedade postId não pode ser vazia ou nula.");
            }
            PostId = postId.Value;
        }
    }
}

