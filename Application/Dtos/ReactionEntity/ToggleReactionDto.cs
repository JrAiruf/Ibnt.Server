namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public class ToggleReactionDto
    {
        
        public Guid MemberId { get; set; }
        public Guid ReactionId { get; set; }
        public Guid EventId { get; set; }
    }
}
