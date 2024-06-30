using App.Application.Dtos.AnnouncementEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<Tuple<AppException?, AnnouncementEntity?>> GetByIdAsync(Guid id)
        {
            try
            {
                var announcement = await _context.Announcement.FindAsync(id);
                if (announcement == null)
                {
                    return Tuple.Create<AppException?, AnnouncementEntity?>
                   (new AnnouncementException($"Item não encontrado. ID: {id}"), null);
                }
                else
                {
                    return Tuple.Create<AppException?, AnnouncementEntity?>(null, announcement);
                }

            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, AnnouncementEntity?>(exception, null);
            }
        }
        public async Task<List<AnnouncementEntity>> GetAllAsync()
        {
            return await _context.Announcement.ToListAsync();
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
