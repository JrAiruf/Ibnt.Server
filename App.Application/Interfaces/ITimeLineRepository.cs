using App.Domain.Entities.TimeLine;

namespace App.Application.Interfaces
{
    public interface ITimeLineRepository
    {
        public Task<TimeLineEntity> StartTimeLine();
        public Task<TimeLineEntity> GetTimeLineAsync();
        public Task PostEvent(Guid eventId);
        public Task RemoveEvent(Guid eventId);
        public Task PostBibleMessage(Guid messageId);
    }
}
