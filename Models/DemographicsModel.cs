using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Demographics 
{
    
    public int DemographicsId {get; set;}

    public string? Spouse {get; set;}

    public string? SpouseEmail { get; set;}

    public string? C1 {get; set;}
    public string? C2 {get; set;}
    public string? C3{get; set;}
    public string? C4{get; set;}
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
        public string? Username {get; set;}


    //each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public string UserId {get; set;}
}