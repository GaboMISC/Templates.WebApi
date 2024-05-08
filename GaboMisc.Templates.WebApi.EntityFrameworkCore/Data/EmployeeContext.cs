using GaboMisc.Templates.WebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace GaboMisc.Templates.WebApi.EntityFrameworkCore.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}