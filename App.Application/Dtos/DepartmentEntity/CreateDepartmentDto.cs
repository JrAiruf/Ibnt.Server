using System.ComponentModel.DataAnnotations;

namespace App.Application.Dtos.DepartmentEntity
{
    public record CreateDepartmentDto([Required] string title);
}
