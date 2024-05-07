namespace Ibnt.Server.Application.Dtos.GloryReactionEntity
{
    public record ReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid EventId { get; init; }
        public bool Toogled { get; init; }
    }
}
