using App.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities.Department
{
    public class DepartmentEntity
    {
        public DepartmentEntity() { }


        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<MemberEntity>? Members { get; set; } = new List<MemberEntity>();
    }
}

