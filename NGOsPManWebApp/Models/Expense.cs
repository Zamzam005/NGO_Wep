using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public String? Expense_Type { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
       


    }
}
