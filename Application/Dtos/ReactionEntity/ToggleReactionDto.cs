namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record ToggleReactionDto
    {
        
        public Guid MemberId { get; init; }
        public Guid ReactionId { get; init; }
    }
}
