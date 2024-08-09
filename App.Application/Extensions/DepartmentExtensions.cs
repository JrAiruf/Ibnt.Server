using App.Application.Dtos.DepartmentEntity;
using App.Domain.Entities.Department;

namespace App.Application.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentDto AsDto(this DepartmentEntity department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Title = department.Title,
                Members = department.Members.Select(m => m.AsDto()).ToList(),
            };
        }
        public static DepartmentEntity FromDto(this CreateDepartmentDto dto)
        {
            return new DepartmentEntity()
            {
                Title = dto.title,
            };
        }
    }
}
