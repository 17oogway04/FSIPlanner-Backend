using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class User
{
    [JsonIgnore]
    public int UserId {get; set;}

    [Required]
    public string? FirstName {get; set;}

    [Required]
    public string? LastName {get; set;}

    [Required]
    public string? UserName {get; set;}

    [Required]
    public string? Password {get; set;}

    public string? ProfilePicture {get; set;}
    
}