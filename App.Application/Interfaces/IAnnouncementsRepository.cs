using App.Application.Dtos.AnnouncementEntity;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;

namespace App.Application.Interfaces
{
    public interface IAnnouncementsRepository
    {
        public Task<Tuple<AppException?, AnnouncementEntity?>> Create(CreateAnnouncementDto newAnnouncement);
        public Task<List<AnnouncementEntity>> GetAllAsync();
        public Task<AnnouncementEntity> GetByIdAsync(Guid id);
        public Task<AnnouncementEntity> Update(Guid id, CreateAnnouncementDto announcement);
        public Task Delete(Guid id);
    }
}
