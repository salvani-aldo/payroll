using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Status
{
    [Key]
    public int StatusId { get; set; }

    public string Status1 { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
