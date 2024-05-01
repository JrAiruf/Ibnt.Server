namespace Ibnt.Server.Application.Dtos.GloryReactionEntity
{
    public class CreateReactionDto
    {
        public string Name { get; set; }
        public Guid MemberId { get; set; }
        public Guid EventId { get; set; }
    }
}
