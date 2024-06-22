namespace App.Application.Dtos.MemberEntity
{
    public record MemberListDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string? ProfileImage { get; init; }
    }
}
