using Ibnt.Server.Application.Dtos.AuthCredentialEntity;

namespace Ibnt.Server.Application.Dtos.MemberEntity
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? ProfileImage { get; set; }
        public AuthResponseDto? Credential { get; set; }
    }
}
