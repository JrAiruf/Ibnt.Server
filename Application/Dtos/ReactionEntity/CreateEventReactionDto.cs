namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record CreateEventReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid EventId { get; init; }
    }
}
