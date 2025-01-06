using Microsoft.EntityFrameworkCore;
using NGOsPManWebApp.Models;

namespace NGOsPManWebApp.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project> tbl_Project { get; set; }
        public DbSet<Donor> tbl_Donor { get; set; }
        public DbSet<Expense> tbl_Expense {  get; set; }
        public DbSet<Employee> tbl_employee { get; set; }
        public DbSet<Ttask> tbl_Tasks { get; set; }
        public DbSet<SignUp> tbl_SignUp { get; set; }
        public DbSet<SignIn> tbl_SignIn { get; set; }

       

    }
}
