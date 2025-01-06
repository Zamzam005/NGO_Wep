using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        public String? DonorName { get; set; }
        public string? Address { get; set; }
        public decimal Number { get; set; }
        public string? Email { get; set; }
        public decimal Don_Amount { get; set; }
        public DateTime Don_Date { get; set; }
        public string? Don_Type { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
       

    }
}
