namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record UntoggleReactionDto
    {
        public Guid MemberId { get; init; }
        public Guid EventId { get; init; }
    }
}
