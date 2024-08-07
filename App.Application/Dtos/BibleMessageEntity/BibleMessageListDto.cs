using App.Application.Dtos.MemberEntity;

namespace App.Application.Dtos.BibleMessageEntity
{
    public record BibleMessageListDto
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public DateTime? PostDate { get; init; }
        public DateTime? CreationDate { get; init; }
        public string? Content { get; init; }
        public string? BaseText { get; init; }
        public string? Type { get; init; }
        public string? EntityType { get; init; }
        public required MemberListDto Member { get; init; }
    }
}
