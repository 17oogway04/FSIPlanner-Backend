using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace fsiplanner_backend.Models;

public class User : IdentityUser
{

    [Required]
    public string? FirstName {get; set;}

    [Required]
    public string? LastName {get; set;}

    public string? ProfilePicture {get; set;}

    [Required]
    public string? Password{get; set;}

    [NotMapped]
    public string? Role {get; set;}
    
}