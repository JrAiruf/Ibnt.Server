using Ibnt.Server.Application.Dtos.AuthCredentialEntity;

namespace Ibnt.Server.Application.Dtos.MemberEntity
{
    public record CreateMemberDto
    {
        public string FullName { get; init; }
        public string? ProfileImage { get; init; }
        public CreateAuthDto Credential { get; init; }
    }
}
