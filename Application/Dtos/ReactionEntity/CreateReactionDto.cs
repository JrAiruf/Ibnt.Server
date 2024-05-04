namespace Ibnt.Server.Application.Dtos.GloryReactionEntity
{
    public class CreateReactionDto
    {
        public Guid MemberId { get; set; }
        public Guid EventId { get; set; }
    }
}
