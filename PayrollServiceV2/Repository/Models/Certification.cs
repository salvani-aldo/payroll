using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class Certification
{
    [Key]
    public int CertificationId { get; set; }

    public string Name { get; set; } = null!;

    public string IsuingOrganization { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? CertificateId { get; set; }

    public string? Url { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int EmployeeId { get; set; }
}
