using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class ResetPasswordModel
{
    [JsonIgnore]
    public int ResetPasswordModelId { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Token { get; set; }
    [Required]
    public string NewPassword { get; set; }
}
