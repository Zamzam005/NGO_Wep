using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? Project_name { get; set; }
        public string? Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public String? status { get; set; }

        public ICollection<Donor>? Donor { get; set; }
        public ICollection<Expense>? Expense { get; set; }
        public ICollection<Ttask>? Ttask { get; set; }


    }
}
