using App.Application.Dtos.DepartmentEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Department;
using App.Domain.Entities.Users;
using App.Domain.Exceptions;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infra.Repositories
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly IbntDbContext _context;

        public DepartmentsRepository(IbntDbContext context)
        {
            _context = context;
        }


        public async Task<Tuple<AppException?, DepartmentEntity?>> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            try
            {
                DepartmentEntity department = dto.FromDto();

                _ = await _context.Department.AddAsync(department);
                _ = await _context.SaveChangesAsync();

                return Tuple.Create<AppException?, DepartmentEntity?>(null, department);
            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, DepartmentEntity?>(exception, null);
            }
        }

        public async Task<Tuple<AppException?, List<DepartmentEntity>?>> GetDepartmentsAsync()
        {
            try
            {
                List<DepartmentEntity> departments = await _context.Department
                    .Include(d => d.Members)
                    .OrderByDescending(d => d.Title)
                    .ToListAsync();

                return Tuple.Create<AppException?, List<DepartmentEntity>?>(null, departments);
            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, List<DepartmentEntity>?>(exception, null);
            }
        }

        public async Task<Tuple<AppException?, DepartmentEntity?>> AddMemberToDepartmentAsync(Guid departmentId, Guid memberId)
        {
            try
            {
                DepartmentEntity? department = await _context.Department.FindAsync(departmentId);
                if (department == null)
                {
                    return Tuple.Create<AppException?, DepartmentEntity?>(new DepartmentException($"Department {departmentId} not found."), null);
                }
                else
                {
                    MemberEntity? member = await _context.Member.FindAsync(memberId);
                    if (member == null)
                        return Tuple.Create<AppException?, DepartmentEntity?>(new DepartmentException($"Member {memberId} not found."), null);

                    department?.Members?.Add(member);

                    _context.Department.Update(department);
                    await _context.SaveChangesAsync();

                    DepartmentEntity? updatedDepartment = await _context.Department.FindAsync(department.Id);

                    return Tuple.Create<AppException?, DepartmentEntity?>(null, updatedDepartment);

                }

            }
            catch (AppException exception)
            {
                return Tuple.Create<AppException?, DepartmentEntity?>(exception, null);
            }
        }

        public async Task<Tuple<AppException?, Task?>> RemoveDepartment(Guid id)
        {
            DepartmentEntity? department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return Tuple.Create<AppException?, Task?>(new DepartmentException($"Department {id} not found."), null);
            }
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return Tuple.Create<AppException?, Task?>(null, null);
        }
    }
}
