using Ibnt.Domain.Entities.TimeLine;

namespace Ibnt.Server.Domain.Entities.TimeLine
{
    public class TimelineEntity
    {
        public TimelineEntity()
        {
         Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public List<BibleMessageEntity>? Messages { get; set; }
        public List<EventEntity>? Events{ get; set; }
    }
}
