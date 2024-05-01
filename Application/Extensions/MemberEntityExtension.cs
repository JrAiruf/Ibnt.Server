using Ibnt.Server.Application.Dtos.MemberEntity;
using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Server.Application.Extensions
{
    public static class MemberEntityExtension
    {
        public static MemberDto AsDto(this MemberEntity member)
        {
            var memberDto = new MemberDto();
            memberDto.Id = member.Id;
            memberDto.FullName = member.FullName;
            memberDto.ProfileImage = member.ProfileImage;
            memberDto.Credential = member.Credential!.AsDto();
            return memberDto;
        }
        public static MemberListDto AsDtoList(this MemberEntity member)
        {
            var memberDto = new MemberListDto();
            memberDto.Id = member.Id;
            memberDto.FullName = member.FullName;
            memberDto.ProfileImage = member.ProfileImage;
            return memberDto;
        }
    }
}
