using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Education
{
    [Key]
    public int EducationId { get; set; }

    public string School { get; set; } = null!;

    public int DegreeId { get; set; }

    public int Year { get; set; }

    public int EmployeeId { get; set; }

    public string Course { get; set; } = null!;

    public virtual Degree Degree { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
