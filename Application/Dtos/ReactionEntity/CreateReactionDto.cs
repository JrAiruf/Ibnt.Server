namespace Ibnt.Server.Application.Dtos.GloryReactionEntity
{
    public record CreateReactionDto
    {
        public Guid MemberId { get; init; }
        public Guid EventId { get; init; }
    }
}
