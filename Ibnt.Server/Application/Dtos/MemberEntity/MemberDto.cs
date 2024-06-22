using Ibnt.Server.Application.Dtos.AuthCredentialEntity;
using Ibnt.Server.Application.Dtos.BibleMessageEntity;

namespace Ibnt.Server.Application.Dtos.MemberEntity
{
    public record MemberDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string? ProfileImage { get; init; }
        public MemberCredentialDto? Credential { get; init; }
    }
}
