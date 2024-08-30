using System.ComponentModel.DataAnnotations.Schema;

namespace fsiplanner_backend.Models;

public class Balance
{
    public int BalanceId { get; set; }

    public string? Type1 { get; set; } //Checking
    public string? Type2 { get; set; } //Currency
    public string? Type3 { get; set; } //Savings
    public string? Type4 { get; set; } //CDs
    public string? Type5 { get; set; } //Health and Medical Savings
    public string? Type6 { get; set; } //Life Insurance
    public string? Type7 { get; set; } //Annuities
    public string? Type8 { get; set; } //Investments
    public string? Type9 { get; set; } //IRAs
    public string? Type10 { get; set; } //Roth IRA
    public string? Type11 { get; set; } //Employer Retirement Plans
    public string? Type12 { get; set; } //Bullion
    public string? Type13 { get; set; } //Primary Residence
    public string? Type14 { get; set; } //Secondary Residence
    public string? Type15 { get; set; } //Real Estate
    public string? Type16 { get; set; } //Business
    public string? Type17 { get; set; } //Trust
    public string? Type18 { get; set; } //Vehicles
    public string? Type19 { get; set; } //Personal Property
    public string? Type20 { get; set; } //Credit Cards
    public string? Type21 { get; set; } //Student Loans
    public string? Type22 { get; set; } //Other

    public string? Username{get; set;}

    [ForeignKey("User")]
    public int UserId { get; set; }
}