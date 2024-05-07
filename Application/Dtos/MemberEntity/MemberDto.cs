using Ibnt.Server.Application.Dtos.AuthCredentialEntity;

namespace Ibnt.Server.Application.Dtos.MemberEntity
{
    public record MemberDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string? ProfileImage { get; init; }
        public AuthResponseDto? Credential { get; init; }
    }
}
