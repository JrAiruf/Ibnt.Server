using Ibnt.Server.Application.Dtos.BibleMessageEntity;
using Ibnt.Server.Application.Dtos.MemberEntity;
using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Server.Application.Extensions
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
                BibleMessages = member.BibleMessages?.Select(b => b.AsDto()).ToList() ?? new List<BibleMessageDto>()
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
    }
}