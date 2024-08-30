using System.ComponentModel.DataAnnotations.Schema;

namespace fsiplanner_backend.Models;

public class Balance
{
    public int BalanceId { get; set; }

    public int? Type1 { get; set; } //Checking
    public int? Type2 { get; set; } //Currency
    public int? Type3 { get; set; } //Savings
    public int? Type4 { get; set; } //CDs
    public int? Type5 { get; set; } //Health and Medical Savings
    public int? Type6 { get; set; } //Life Insurance
    public int? Type7 { get; set; } //Annuities
    public int? Type8 { get; set; } //Investments
    public int? Type9 { get; set; } //IRAs
    public int? Type10 { get; set; } //Roth IRA
    public int? Type11 { get; set; } //Employer Retirement Plans
    public int? Type12 { get; set; } //Bullion
    public int? Type13 { get; set; } //Primary Residence
    public int? Type14 { get; set; } //Secondary Residence
    public int? Type15 { get; set; } //Real Estate
    public int? Type16 { get; set; } //Business
    public int? Type17 { get; set; } //Trust
    public int? Type18 { get; set; } //Vehicles
    public int? Type19 { get; set; } //Personal Property
    public int? Type20 { get; set; } //Credit Cards
    public int? Type21 { get; set; } //Student Loans
    public int? Type22 { get; set; } //Other

    public string? Username{get; set;}

    [ForeignKey("User")]
    public int UserId { get; set; }
}