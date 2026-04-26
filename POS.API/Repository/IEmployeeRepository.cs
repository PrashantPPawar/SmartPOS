using POS.API.DTOs;

namespace POS.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetAll();
        Task Save(EmployeeDto dto);
        Task Delete(int id);
        Task<EmployeeDto> Login(string username, string passwordHash);
    }
}
