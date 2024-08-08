using App.Application.Dtos.DepartmentEntity;
using App.Domain.Entities.Department;
using App.Domain.Exceptions;

namespace App.Application.Interfaces
{
    public interface IDepartmentsRepository
    {
        public Task<Tuple<AppException?, DepartmentEntity?>> CreateDepartmentAsync(CreateDepartmentDto department);
        public Task<Tuple<AppException?, Task>> RemoveDepartment(Guid id);
        public Task<Tuple<AppException?, DepartmentEntity?>> AddMemberToDepartmentAsync(Guid departmentId, Guid memberId);
        public Task<Tuple<AppException?, List<DepartmentEntity>?>> GetDepartmentsAsync();
    }
}
