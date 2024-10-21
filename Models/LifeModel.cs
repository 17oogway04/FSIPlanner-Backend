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

public string? Premium {get; set;}

public double? CashValue {get; set;}

public string? DeathBenefitOne {get; set;}

public string? DeathBenefitTwo {get; set;}

public string? Riders {get; set;}

public string? RidersBenefit {get; set;}

public string? PercentageToSavings {get; set;}
    public string? Username {get; set;}


//each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public int UserId {get; set;}
}