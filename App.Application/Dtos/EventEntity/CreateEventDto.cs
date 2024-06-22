namespace App.Application.Dtos.EventEntity
{
    public record CreateEventDto
    {
        public string Title { get; init; }
        public DateTime? PostDate { get; init; }
        public DateTime? Date { get; init; }
        public string? ImageUrl { get; init; }
        public string Description { get; init; }
    }
}
