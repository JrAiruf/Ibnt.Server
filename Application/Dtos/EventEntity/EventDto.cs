
using Ibnt.Server.Application.Dtos.GloryReactionEntity;

namespace Ibnt.Server.Application.Dtos.EventEntity
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public List<ReactionDto>? Reactions { get; set; }
    }
}
