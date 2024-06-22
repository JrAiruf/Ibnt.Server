using Ibnt.Server.Application.Dtos.ReactionEntity;
using Ibnt.Server.Application.Dtos.MemberEntity;

namespace Ibnt.Server.Application.Dtos.BibleMessageEntity
{
    public record BibleMessageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? Content { get; set; }
        public string? BaseText { get; set; }
        public string? Type{ get; set; }
        public string EntityType { get; set; }
        public List<BibleMessageReactionDto>? Reactions { get; set; }
        public Guid MemberId { get; set; }
    }
}
