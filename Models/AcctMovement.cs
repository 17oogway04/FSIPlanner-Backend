using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fsiplanner_backend;

public class AcctMovement
{
    public int AcctMovementId { get; set; }
    [Required]
    public required string FullOrPartial { get; set; }

    [Required]
    public required string CompanyFrom { get; set; }

    [Required]
    public required string CompanyTo { get; set; }

    [Required]
    public double DollarAmt { get; set; }

    [Required]
    public required string Date { get; set; }

    public string? Username {get; set;}

    [ForeignKey("User")]
    public string UserId { get; set; }
}
