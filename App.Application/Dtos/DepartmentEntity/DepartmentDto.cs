using App.Application.Dtos.MemberEntity;

namespace App.Application.Dtos.DepartmentEntity
{
    public record DepartmentDto
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required List<MemberListDto> Members { get; init; }
    }
}
