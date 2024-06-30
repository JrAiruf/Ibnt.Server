using App.Application.Dtos.AnnouncementEntity;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;

namespace App.Application.Interfaces
{
    public interface IAnnouncementsRepository
    {
        public Task<Tuple<AppException?, AnnouncementEntity?>> Create(CreateAnnouncementDto newAnnouncement);
        public Task<List<AnnouncementEntity>> GetAllAsync();
        public Task<Tuple<AppException?, AnnouncementEntity?>> GetByIdAsync(Guid id);
        public Task<Tuple<AppException?, AnnouncementEntity?>> UpdateAsync(Guid id, UpdateAnnouncementDto announcement);
        public Task<Tuple<AppException?, Guid?>> DeleteAsync(Guid id);
    }
}
