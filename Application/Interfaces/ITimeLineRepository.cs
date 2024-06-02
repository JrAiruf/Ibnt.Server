using Ibnt.Server.Domain.Entities.TimeLine;

namespace Ibnt.Server.Application.Interfaces
{
    public interface ITimeLineRepository
    {
        public Task<TimeLineEntity> StartTimeLine();
        public Task<TimeLineEntity> GetTimeLineAsync();
        public Task PostEvent(Guid eventId);
        public Task PostBibleMessage(Guid messageId);
    }
}
