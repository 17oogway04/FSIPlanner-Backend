using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class DisabilityInsurance
{
    public int DisabilityInsId {get; set;}

    public string? PolicyName {get; set;}

    public string? PolicyType {get; set;} //STDI, LTDI, LTC, ACC, CI, CAN

    public string? Owner {get; set;}

    public string? Insured {get; set;}

    public double? Premium {get; set;}

    public double? CashValue {get; set;}

    public double? MonthlyDeathBenefitOne {get; set;}

    public double? MonthlyDeathBenefitTwo {get; set;}

    public string? Riders {get; set;}

    public double? RidersBenefit {get; set;}

    public double? EliminationPeriod {get; set;}

    public double? BenefitPeriod {get; set;}
        public string? Username {get; set;}


    //each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public string UserId {get; set;}
}