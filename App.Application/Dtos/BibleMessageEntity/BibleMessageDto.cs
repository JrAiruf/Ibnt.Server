using App.Application.Dtos.ReactionEntity;
using App.Application.Dtos.MemberEntity;

namespace App.Application.Dtos.BibleMessageEntity
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
