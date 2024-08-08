using App.Application.Dtos.AuthCredentialEntity;

namespace App.Application.Dtos.MemberEntity
{
    public record UpdateMemberDto(string? fullName, string profileImage);
}
