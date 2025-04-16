using System.ComponentModel.DataAnnotations.Schema;

namespace fsiplanner_backend.Models;

public class Balance
{
    public int BalanceId { get; set; }

    public double? Type1 { get; set; } //Checking
    public double? Type2 { get; set; } //Currency
    public double? Type3 { get; set; } //Savings
    public double? Type4 { get; set; } //CDs
    public double? Type5 { get; set; } //Health and Medical Savings
    public double? Type6 { get; set; } //Life Insurance
    public double? Type7 { get; set; } //Annuities
    public double? Type8 { get; set; } //Investments
    public double? Type9 { get; set; } //IRAs
    public double? Type10 { get; set; } //Roth IRA
    public double? Type11 { get; set; } //Employer Retirement Plans
    public double? Type12 { get; set; } //Bullion
    public double? Type13 { get; set; } //Primary Residence
    public double? Type14 { get; set; } //Secondary Residence
    public double? Type15 { get; set; } //Real Estate
    public double? Type16 { get; set; } //Business
    public double? Type17 { get; set; } //Trust
    public double? Type18 { get; set; } //Vehicles
    public double? Type19 { get; set; } //Personal Property
    public double? Type20 { get; set; } //Credit Cards
    public double? Type21 { get; set; } //Student Loans
    public double? Type22 { get; set; } //Other

    public string? Username{get; set;}

    [ForeignKey("User")]
    public int UserId { get; set; }
}