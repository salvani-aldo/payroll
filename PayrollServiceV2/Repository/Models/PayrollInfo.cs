using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class PayrollInfo
{
    [Key]
    public int PayrollInfoId { get; set; }

    public double? BasePay { get; set; }

    public string? Sss { get; set; }

    public string? Tin { get; set; }

    public string? Phic { get; set; }

    public string? Pagibig { get; set; }
}
