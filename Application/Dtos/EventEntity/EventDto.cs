
using Ibnt.Server.Application.Dtos.GloryReactionEntity;

namespace Ibnt.Server.Application.Dtos.EventEntity
{
    public record EventDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string? ImageUrl { get; init; }
        public DateTime? PostDate { get; init; }
        public DateTime? Date { get; init; }
        public string Description { get; init; }
        public List<ReactionDto>? Reactions { get; init; }
    }
}
