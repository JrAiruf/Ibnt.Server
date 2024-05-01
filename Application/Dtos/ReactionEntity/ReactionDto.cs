namespace Ibnt.Server.Application.Dtos.GloryReactionEntity
{
    public class ReactionDto
    {
        public string Name { get; set; }
        public Guid MemberId { get; set; }
        public Guid EventId { get; set; }
        public bool Toogled { get; set; }
    }
}
