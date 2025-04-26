using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Configs
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClientCompany> ClientCompanies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ChallanTag> ChallanTags { get; set; }
        public DbSet<ChallanItem> ChallanItems { get; set; }
        public DbSet<EmployeeChallanItemRate> EmployeeChallanItemRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the table name is in lowercase and matches the database table
            modelBuilder.Entity<ClientCompany>().ToTable("client_company");
            modelBuilder.Entity<Employee>().ToTable("employee");


           



            base.OnModelCreating(modelBuilder);
        }
    }
}
