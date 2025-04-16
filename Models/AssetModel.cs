using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Assets
{
    public int AssetId {get; set;}

    [Required]
    public string? Custodian {get; set;}

    [Required]
    public string? AccountNumber {get; set;}

    public string? RateOfReturn {get; set;}

    public string? TaxStructure {get; set;}

    public string? ValuationDate {get; set;}

    public string? MaturityDate {get; set;}

    [Required]
    public double? Balance {get; set;}

    [Required]
    public string? Type {get; set;}

    public string? AssetName{get; set;} //spend, save, or invest

    [Required]
    public string? Bucket {get; set;}
    public string? Username {get; set;}

    //each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public string UserId {get; set;}
}

public class BucketSummary
{
    public int BucketId {get; set;}
    public string? Type {get; set;}
    public string? Bucket {get; set;}
    public double? Balance {get; set;}

    public string? Username{ get; set;}
    [ForeignKey("User")]
    public string UserId {get; set;}
}