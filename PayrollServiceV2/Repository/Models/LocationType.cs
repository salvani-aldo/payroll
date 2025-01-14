using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class LocationType
{
    [Key]
    public int LocationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime Created { get; set; }
}
