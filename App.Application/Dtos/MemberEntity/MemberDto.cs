using App.Application.Dtos.AuthCredentialEntity;

namespace App.Application.Dtos.MemberEntity
{
    public record MemberDto
    {
        public Guid Id { get; init; }
        public required string FullName { get; init; }
        public string? ProfileImage { get; init; }
        public MemberCredentialDto? Credential { get; init; }
    }
}
