using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class Ttask
    {
        [Key]
        public int TtaskId { get; set; }
        public String? Task_Name { get; set; }
        public DateTime Due_Date { get; set; }
        public String? Status { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public Project? Project { get; set; }
        public Employee? Employee { get; set; }
        
    }
}
 