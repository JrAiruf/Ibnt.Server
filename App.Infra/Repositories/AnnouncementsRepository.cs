using App.Application.Dtos.AnnouncementEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;
using App.Infra.Data;

namespace App.Infra.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly IbntDbContext _context;

        public AnnouncementsRepository(IbntDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<AppException?, AnnouncementEntity?>> Create(CreateAnnouncementDto newAnnouncement)
        {
            try
            {
                var announcement = newAnnouncement.FromDto();

                await _context.Announcement.AddAsync(announcement);
                await _context.SaveChangesAsync();

                return Tuple.Create<AppException?, AnnouncementEntity?>(null, announcement);
            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, AnnouncementEntity?>(exception, null);
            }
        }

        public Task<AnnouncementEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<List<AnnouncementEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnnouncementEntity> Update(Guid id, CreateAnnouncementDto announcement)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
