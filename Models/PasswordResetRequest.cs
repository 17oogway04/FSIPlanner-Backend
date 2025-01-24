using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class PasswordResetRequest
{
    [JsonIgnore]
    public int PasswordResetRequestId { get; set;}

    [Required]
    public string Email { get; set;}
}
