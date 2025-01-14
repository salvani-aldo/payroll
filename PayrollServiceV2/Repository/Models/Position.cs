using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Position
{
    [Key]
    public int PositionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
