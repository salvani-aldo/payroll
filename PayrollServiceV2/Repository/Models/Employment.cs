using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Employment
{
    [Key]
    public int EmployementId { get; set; }

    public string Title { get; set; } = null!;

    public int EmploymentTypeId { get; set; }

    public string Company { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int LocationTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }
}
