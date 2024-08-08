using App.Application.Dtos.MemberEntity;
using App.Domain.Entities.Users;

namespace App.Application.Extensions
{
    public static class MemberEntityExtension
    {
        public static MemberDto AsDto(this MemberEntity member)
        {
            return new MemberDto()
            {
                Id = member.Id,
                FullName = member.FullName,
                ProfileImage = member.ProfileImage,
                Credential = member.Credential.AsCredentialDto(),
            };
        }
        public static MemberListDto AsDtoList(this MemberEntity member)
        {
            return new MemberListDto
            {
                Id = member.Id,
                FullName = member.FullName,
                ProfileImage = member.ProfileImage,
            };
        }

        public static MemberEntity FromDto(this UpdateMemberDto dto)
        {
            return new MemberEntity(
                dto.fullName,
                dto.profileImage,
                null
                );
        }
    }
}