using System.ComponentModel.DataAnnotations;
namespace Repository.Models;

public partial class Country
{
    [Key]
    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }
}
