using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
