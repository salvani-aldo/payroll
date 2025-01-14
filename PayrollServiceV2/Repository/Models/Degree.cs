using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Degree
{
    [Key]
    public int DegreeId { get; set; }

    public string Degree1 { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
