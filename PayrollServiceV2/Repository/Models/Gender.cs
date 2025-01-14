using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Gender
{
    [Key]
    public int GenderId { get; set; }

    public string Gender1 { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
