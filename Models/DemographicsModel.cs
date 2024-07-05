using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Demographics 
{
    [JsonIgnore]
    public int DemographicsId {get; set;}

    public string? SocialSecurity {get; set;} //work on adding security to this

    public string? DriversLicense {get; set;}

    public string? IssueDate {get; set;}

    public string? ExpirationDate {get; set;}

    public string? Gender{get; set;}

    public string? MaritalStatus {get; set;}

    public string? Employer {get; set;}

    public string? Occupation {get; set;}

    public string? WorkPhone {get; set;}

    public string? Address {get; set;}

    public string? PhoneNumber {get; set;}

    [EmailAddress]
    public string? Email {get; set;}

    public string? Birthday {get; set;}
}