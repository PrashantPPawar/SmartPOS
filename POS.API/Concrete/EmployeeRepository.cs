using POS.API.DTOs;
using POS.API.Repository;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore; // Add this for DbContext and related EF Core types

// Add the correct using for AppDbContext if it exists in another namespace
// For example, if AppDbContext is in POS.API.Data:
using POS.API.Data;
using Microsoft.Data.SqlClient; // <-- Change this to the actual namespace where AppDbContext is defined

namespace POS.API.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            return await _context.Employees
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName,
                    BranchName = x.BranchName,
                    Mobile = x.Mobile,
                    Department = x.Department,
                    Designation = x.Designation,
                    IsActive = x.IsActive
                }).ToListAsync();
        }

        public async Task Save(EmployeeDto dto)
        {
            var conn = _context.Database.GetDbConnection();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "sp_SaveEmployee";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Id", (object?)dto.Id ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Name", dto.Name));
            cmd.Parameters.Add(new SqlParameter("@UserName", dto.UserName));
            cmd.Parameters.Add(new SqlParameter("@PasswordHash", dto.PasswordHash)); // hash later
            cmd.Parameters.Add(new SqlParameter("@BranchName", dto.BranchName));
            cmd.Parameters.Add(new SqlParameter("@Phone", dto.Phone));
            cmd.Parameters.Add(new SqlParameter("@Mobile", dto.Mobile));
            cmd.Parameters.Add(new SqlParameter("@Gender", dto.Gender));
            cmd.Parameters.Add(new SqlParameter("@BirthDate", dto.BirthDate));
            cmd.Parameters.Add(new SqlParameter("@JoiningDate", dto.JoiningDate));
            cmd.Parameters.Add(new SqlParameter("@Department", dto.Department));
            cmd.Parameters.Add(new SqlParameter("@SubDepartment", dto.SubDepartment));
            cmd.Parameters.Add(new SqlParameter("@Designation", dto.Designation));
            cmd.Parameters.Add(new SqlParameter("@Email", dto.Email));
            cmd.Parameters.Add(new SqlParameter("@Address", dto.Address));
            cmd.Parameters.Add(new SqlParameter("@IsActive", dto.IsActive));
            cmd.Parameters.Add(new SqlParameter("@IsAdmin", dto.IsAdmin));
            cmd.Parameters.Add(new SqlParameter("@Basic", dto.Basic));
            cmd.Parameters.Add(new SqlParameter("@DA", dto.DA));
            cmd.Parameters.Add(new SqlParameter("@HRA", dto.HRA));
            cmd.Parameters.Add(new SqlParameter("@GrossSalary", dto.GrossSalary));

            if (conn.State != ConnectionState.Open)
                await conn.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteEmployee @Id",
                new SqlParameter("@Id", id));
        }

        public async Task<EmployeeDto> Login(string username, string passwordHash)
        {
            return await _context.Employees
                .Where(x => x.UserName == username && x.PasswordHash == passwordHash && x.IsActive)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName
                }).FirstOrDefaultAsync();
        }
    }
}
