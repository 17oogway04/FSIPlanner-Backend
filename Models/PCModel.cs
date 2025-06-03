using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class PC
{
    public int PCId {get; set;}
    public string? CompanyName {get; set;}
    public string? PolicyType {get; set;}
    public double? Premium {get; set;}
    public string? ExpirationDate {get; set;}
    public double? Deductible {get; set;}
    public double? LiabilityLimit {get; set;}
    public string? Username {get; set;}


    [ForeignKey("User")]
    public string UserId {get; set;}
}