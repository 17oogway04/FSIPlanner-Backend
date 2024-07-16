using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Migrations;

public class FSIPlannerDbContext : DbContext
{
 public DbSet<User> User { get; set;}
 public DbSet<Assets> Asset {get; set;}
 public DbSet<Demographics> Demographics {get; set;}
 public DbSet<DisabilityInsurance> DisabilityIns {get; set;}
 public DbSet<Liabilities> Liabilites {get; set;}
 public DbSet<Life> Life {get; set;}
 public DbSet<PC> PC {get; set;}
 public DbSet<Notes> Notes {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.UserName).IsRequired();
            entity.HasIndex(x => x.UserName).IsUnique();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.ProfilePicture);
        });

        modelBuilder.Entity<Assets>(entity => {
            entity.HasKey(e => e.AssetId);
            entity.Property(e => e.Custodian).IsRequired();
            entity.Property(e => e.AccountNumber).IsRequired();
            entity.Property(e => e.RateOfReturn);
            entity.Property(e => e.TaxStructure);
            entity.Property(e => e.ValuationDate);
            entity.Property(e => e.MaturityDate);
            entity.Property(e => e.Balance).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.Bucket);
            //matching up users to their asset page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<Demographics>(entity => {
            entity.HasKey(e => e.DemographicsId);
            entity.Property(e => e.SocialSecurity);
            entity.Property(e => e.DriversLicense);
            entity.Property(e => e.IssueDate);
            entity.Property(e => e.ExpirationDate);
            entity.Property(e => e.Gender);
            entity.Property(e => e.MaritalStatus);
            entity.Property(e => e.Employer);
            entity.Property(e => e.Occupation);
            entity.Property(e => e.WorkPhone);
            entity.Property(e => e.Address);
            entity.Property(e => e.PhoneNumber);
            entity.Property(e => e.Email);
            entity.Property(e => e.Birthday);
            //matching up users to their demographic page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<Liabilities>(entity => {
            entity.HasKey(e => e.LiabilitiesId);
            entity.Property(e => e.Type);
            entity.Property(e => e.Description);
            entity.Property(e => e.Balance);
            entity.Property(e => e.Rate);
            entity.Property(e => e.Payment);
            entity.Property(e => e.Term);
            entity.Property(e => e.Value);
            //matching up users to their liability page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<Life>(entity => {
            entity.HasKey(e => e.LifeId);
            entity.Property(e => e.PolicyName);
            entity.Property(e => e.PolicyType);
            entity.Property(e => e.Owner);
            entity.Property(e => e.Insured);
            entity.Property(e => e.Premium);
            entity.Property(e => e.CashValue);
            entity.Property(e => e.DeathBenefitOne);
            entity.Property(e => e.DeathBenefitTwo);
            entity.Property(e => e.Riders);
            entity.Property(e => e.RidersBenefit);
            entity.Property(e => e.PercentageToSavings);
            //matching up users to their life page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<PC>(entity => {
            entity.HasKey(e => e.PCId);
            entity.Property(e => e.CompanyName);
            entity.Property(e => e.PolicyType);
            entity.Property(e => e.Premium);
            entity.Property(e => e.ExpirationDate);
            entity.Property(e => e.Deductible);
            entity.Property(e => e.LiabilityLimit);
            //matching up users to their PC page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

         modelBuilder.Entity<DisabilityInsurance>(entity => {
            entity.HasKey(e => e.DisabilityInsId);
            entity.Property(e => e.PolicyName);
            entity.Property(e => e.PolicyType);
            entity.Property(e => e.Owner);
            entity.Property(e => e.Insured);
            entity.Property(e => e.Premium);
            entity.Property(e => e.CashValue);
            entity.Property(e => e.MonthlyDeathBenefitOne);
            entity.Property(e => e.MonthlyDeathBenefitTwo);
            entity.Property(e => e.Riders);
            entity.Property(e => e.RidersBenefit);
            entity.Property(e => e.EliminationPeriod);
            entity.Property(e => e.BenefitPeriod);
            //matching up users to their disability insurance page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<Notes>(entity => {
            entity.HasKey(e => e.NotesId);
            entity.Property(e => e.Subject);
            entity.Property(e => e.Description);
            entity.Property(e => e.CreatedAt);
            //matching up users to their notes page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });
    }
}