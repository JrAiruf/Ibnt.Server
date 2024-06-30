namespace App.Application.Dtos.AnnouncementEntity
{
    public record UpdateAnnouncementDto(string title, string description, string dateString, bool fixedWarning);
}
