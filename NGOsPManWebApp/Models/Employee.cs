using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public String? Emp_FullName { get; set; }
        public decimal Number { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public DateTime Join_Date { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Ttask>? Ttask { get; set; }


    }
}
