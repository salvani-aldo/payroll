using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository;

public partial class PayrollContext : DbContext
{
    public PayrollContext()
    {
    }

    public PayrollContext(DbContextOptions<PayrollContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<Certification> Certification { get; set; }

    public virtual DbSet<Country> Countrie { get; set; }

    public virtual DbSet<Degree> Degree { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<Education> Education { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Employment> Employment { get; set; }

    public virtual DbSet<EmploymentType> EmploymentType { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<LocationType> LocationType { get; set; }

    public virtual DbSet<PayrollInfo> PayrollInfo { get; set; }

    public virtual DbSet<Position> Position { get; set; }

    public virtual DbSet<State> State { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
