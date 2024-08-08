using App.Application.Dtos.DepartmentEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Department;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsRepository _repository;
        public DepartmentsController(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<Results<NotFound<string>, Ok<List<DepartmentDto>>>> GetGetDepartmentsAsync()
        {
            (AppException? exception, List<DepartmentEntity>? departmentsList) = await _repository.GetDepartmentsAsync();
            if (exception != null)
            {
                return TypedResults.NotFound("[]");
            }
            else
            {
                List<DepartmentDto> departments = departmentsList.Select(d => d.AsDto()).ToList();
                return TypedResults.Ok(departments);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<Results<BadRequest<string>, Created<DepartmentDto>>> CreateDepartmentAsync([FromBody] CreateDepartmentDto dto)
        {
            (AppException? exception, DepartmentEntity? department) = await _repository.CreateDepartmentAsync(dto);

            return exception != null
                ? (Results<BadRequest<string>, Created<DepartmentDto>>)TypedResults.BadRequest(exception.Message)
                : (Results<BadRequest<string>, Created<DepartmentDto>>)TypedResults.Created("/api/[controller]", department!.AsDto());
        }

        [HttpPost("members/{departmentId}/{memberId}")]
        [Authorize(Roles = "admin")]
        public async Task<Results<BadRequest<string>, Ok<DepartmentDto>>> AddMemberToDepartmentAsync(Guid departmentId, Guid memberId)
        {
            (AppException? exception, DepartmentEntity? department) = await _repository.AddMemberToDepartmentAsync(departmentId, memberId);
            if (exception != null)
            {
                return (Results<BadRequest<string>, Ok<DepartmentDto>>)TypedResults.BadRequest(exception.Message);
            }
            else
            {
                return (Results<BadRequest<string>, Ok<DepartmentDto>>)TypedResults.Ok(department!.AsDto());
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<Results<NotFound<string>, NoContent>> RemoveDepartment(Guid id)
        {
            (AppException? exception, Task? _) = await _repository.RemoveDepartment(id);
            return exception != null
                ? TypedResults.NotFound(exception.Message)
                : TypedResults.NoContent();
        }
    }
}
