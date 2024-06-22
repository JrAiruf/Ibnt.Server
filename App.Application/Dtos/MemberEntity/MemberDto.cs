using App.Application.Dtos.AuthCredentialEntity;
using App.Application.Dtos.BibleMessageEntity;

namespace App.Application.Dtos.MemberEntity
{
    public record MemberDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string? ProfileImage { get; init; }
        public MemberCredentialDto? Credential { get; init; }
    }
}
