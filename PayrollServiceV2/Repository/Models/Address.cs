using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Address
{
    [Key]
    public int AddressId { get; set; }

    public int EmployeeId { get; set; }

    public string? Street { get; set; }

    public int ZipCode { get; set; }

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public int CountryId { get; set; }

    public DateTime Created { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
