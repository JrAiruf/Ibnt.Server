namespace App.Application.Dtos.AnnouncementEntity
{
    public record CreateAnnouncementDto(Guid memberId, string title, string description, string dateString);
}
