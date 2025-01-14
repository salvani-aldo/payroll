using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class EmploymentType
{
    [Key]
    public int EmployementTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime Created { get; set; }
}
