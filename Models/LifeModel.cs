using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Life
{

public int LifeId {get; set;}

public string? PolicyName {get; set;}

public string? PolicyType {get; set;} //Term, Universal, Variable, Whole Life

public string? Owner {get; set;}

public string? Insured {get; set;}

public double? Premium {get; set;}

public double? CashValue {get; set;}

public double? DeathBenefitOne {get; set;}

public double? DeathBenefitTwo {get; set;}

public string? Riders {get; set;}

public double? RidersBenefit {get; set;}

public double? PercentageToSavings {get; set;}
    public string? Username {get; set;}


//each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public string UserId {get; set;}
}