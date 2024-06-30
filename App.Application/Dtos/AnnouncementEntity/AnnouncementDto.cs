namespace App.Application.Dtos.AnnouncementEntity
{
    public record AnnouncementDto(Guid id, Guid memberId, string title, string description, string dateString, bool fixedWarning);
}
