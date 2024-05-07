namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public class ToggleReactionDto
    {
        
        public Guid MemberId { get; init; }
        public Guid ReactionId { get; init; }
        public Guid EventId { get; init; }
    }
}
