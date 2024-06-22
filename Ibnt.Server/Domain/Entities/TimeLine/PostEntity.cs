using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Domain.Entities.TimeLine
{
    public class PostEntity : TimeLineContent
    {

        public string EntityType { get; private set; } = "post";
        public List<ReactionPostEntity>? Reactions { get; private set; }
        public MemberEntity? Member { get;  set; }

    }
}
