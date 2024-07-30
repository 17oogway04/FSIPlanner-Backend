using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Assets
{
    [JsonIgnore]
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
    public decimal? Balance {get; set;}

    [Required]
    public string? Type {get; set;}

    public string? Bucket {get; set;}
        public string? Username {get; set;}



    //each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public int UserId {get; set;}
}

public class BucketSummary
{
    public string? Type {get; set;}
    public decimal? Balance {get; set;}
    [ForeignKey("User")]
    public int UserId {get; set;}
}