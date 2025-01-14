using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class State
{
    [Key]
    public int StateId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }
}
