using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? PositionId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public int CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int GenderId { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual Position? Position { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User? UpdatedBy { get; set; }
}
