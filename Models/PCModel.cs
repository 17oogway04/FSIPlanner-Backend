using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class PC
{
    [JsonIgnore]
    public int PCId {get; set;}
    public string? CompanyName {get; set;}
    public string? PolicyType {get; set;}
    public string? Premium {get; set;}
    public string? ExpirationDate {get; set;}
    public string? Deductible {get; set;}

    [ForeignKey("User")]
    public int UserId {get; set;}
}