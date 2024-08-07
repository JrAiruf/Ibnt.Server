﻿using App.Application.Dtos.AnnouncementEntity;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;

namespace App.Tests.Mocks.AnnouncementMocks
{
    public static class AnnouncementMocks
    {
        static string announcementDate = "2024-06-25";
        public static AnnouncementException annoucementException = new AnnouncementException("Announcement Not Created.");

        public static AnnouncementEntity announcement = new AnnouncementEntity(
            Guid.NewGuid(),
            "TITLE",
            "DESCRIPTION",
            announcementDate,
            false
            );

        public static CreateAnnouncementDto announcementDto = new CreateAnnouncementDto(
               Guid.NewGuid(),
               "TITLE",
               "DESCRIPTION",
               announcementDate,
               false
               );
        
        public static UpdateAnnouncementDto updateDto = new UpdateAnnouncementDto(
               "TITLE",
               "DESCRIPTION",
               announcementDate,
               true
               );

        public static List<AnnouncementEntity> list = new()
            {
            announcement,
            announcement,
            announcement,
            announcement,
            announcement,
            announcement,
            };
        
        public static List<CreateAnnouncementDto> creationList = new()
            {
            announcementDto,
            announcementDto,
            announcementDto,
            };
    }
}
