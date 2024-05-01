namespace Ibnt.Server.Application.Dtos.EventEntity
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? Date { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
