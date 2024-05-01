using Ibnt.Server.Application.Dtos.AuthCredentialEntity;

namespace Ibnt.Server.Application.Dtos.MemberEntity
{
    public class CreateMemberDto
    {
        public string FullName { get; set; }
        public string? ProfileImage { get; set; }
        public CreateAuthDto Credential { get; set; }
    }
}
