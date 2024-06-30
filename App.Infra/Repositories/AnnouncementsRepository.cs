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

        public async Task<Tuple<AppException?, AnnouncementEntity?>> UpdateAsync(Guid id, UpdateAnnouncementDto dto)
        {
            try
            {
                var (exception, announcement) = await GetByIdAsync(id);
                if (announcement == null)
                {
                    return Tuple.Create<AppException?, AnnouncementEntity?>(exception, null);
                }
                else
                {
                    announcement.ChangeTitle(dto.title);
                    announcement.ChangeDescription(dto.description);
                    announcement.ChangeDate(dto.dateString);
                    announcement.ChangeFixedStatus(dto.fixedWarning);

                    _context.Announcement.Update(announcement);
                    await _context.SaveChangesAsync();

                    return Tuple.Create<AppException?, AnnouncementEntity?>(null, announcement);
                }

            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, AnnouncementEntity?>(exception, null);
            }
        }

        public async Task<Tuple<AppException?, Guid?>> DeleteAsync(Guid id)
        {
            try
            {
                var (exception, announcement) = await GetByIdAsync(id);
                if (announcement == null)
                {
                    return Tuple.Create<AppException?, Guid?>(exception, null);
                }
                else
                {
                    _context.Announcement.Remove(announcement);
                    await _context.SaveChangesAsync();

                    return Tuple.Create<AppException?, Guid?>(null, id);
                }
            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, Guid?>(exception, null);
            }
        }

    }
}
