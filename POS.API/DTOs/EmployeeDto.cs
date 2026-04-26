namespace POS.API.DTOs
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Basic { get; set; }
        public decimal DA { get; set; }
        public decimal HRA { get; set; }
        public decimal GrossSalary { get; set; }
    }
}
