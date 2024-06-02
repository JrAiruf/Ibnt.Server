using Ibnt.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Reactions
{
    public class ReactionPostEntity : BaseReaction
    {
        public Guid PostId { get; private set; }
        public bool Toogled { get; private set; } = true;
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

