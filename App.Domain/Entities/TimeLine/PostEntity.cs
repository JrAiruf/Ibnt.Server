using App.Domain.Entities.Reactions;
using App.Domain.Entities.Users;

namespace App.Domain.Entities.TimeLine
{
    public class PostEntity : TimeLineContent
    {

        public string EntityType { get; private set; } = "post";
        public List<ReactionPostEntity>? Reactions { get; private set; }
        public MemberEntity? Member { get; set; }

    }
}
