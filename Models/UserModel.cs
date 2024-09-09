using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace fsiplanner_backend.Models;

public class User
{
    //JsonIgnore
    [JsonIgnore]
    public int UserId {get; set;}

    [Required]
    public string? FirstName {get; set;}

    [Required]
    public string? LastName {get; set;}

    [Required]
    public string? UserName {get; set;}

    public string? HashedUsername {get; set;}
    public string? HashedUserId {get; set;}
    [Required]
    public string? Password {get; set;}

    public string? ProfilePicture {get; set;}
    
}