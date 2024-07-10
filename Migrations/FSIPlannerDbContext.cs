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
    //PC Model
    //Notes Model

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
            //matching up ussers to each asset page
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.UserId).IsRequired();
        });
    }
}