using Ibnt.Server.Domain.Entities.TimeLine;

namespace Ibnt.Domain.Entities.TimeLine
{
    public class PostEntity : TimeLineContent
    {
        public string EntityType { get; private set; } = "post";
    }
}
