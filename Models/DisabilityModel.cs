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

    public string? Premium {get; set;}

    public string? CashValue {get; set;}

    public string? MonthlyDeathBenefitOne {get; set;}

    public string? MonthlyDeathBenefitTwo {get; set;}

    public string? Riders {get; set;}

    public string? RidersBenefit {get; set;}

    public string? EliminationPeriod {get; set;}

    public string? BenefitPeriod {get; set;}
        public string? Username {get; set;}


    //each user matched up to their corresponding asset sheet
    [ForeignKey("User")]
    public int UserId {get; set;}
}