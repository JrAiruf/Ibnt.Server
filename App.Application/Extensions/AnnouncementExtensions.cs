﻿using App.Application.Dtos.AnnouncementEntity;
using App.Domain.Entities.Announcement;

namespace App.Application.Extensions
{
    public static class AnnouncementExtensions
    {

        public static AnnouncementEntity FromDto(this CreateAnnouncementDto dto)
        {
            return new(
                dto.memberId,
                dto.title,
                dto.description,
                dto.dateString,
                dto.fixedWarning
                );
        }

        public static AnnouncementDto AsDto(this AnnouncementEntity entity)
        {
            return new(
                entity.Id,
                entity.MemberId,
                entity.Title,
                entity.Description,
                entity.Date.ToString(),
                entity.FixedWarning
                );
        }

        public static AnnouncementEntity FromDto(this UpdateAnnouncementDto dto)
        {
            return new(
                dto.title,
                dto.description,
                dto.dateString,
                dto.fixedWarning
                );
        }
    }
}
