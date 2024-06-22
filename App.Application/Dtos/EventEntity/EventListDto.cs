namespace App.Application.Dtos.EventEntity
{
    public  record EventListDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string? ImageUrl { get; init; }
        public string? EntityType{ get; init; }
        public DateTime? PostDate { get; init; }
        public DateTime? Date { get; init; }
        public string Description { get; init; }
    }
}
