using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Admin { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
