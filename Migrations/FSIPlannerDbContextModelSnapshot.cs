﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fsiplanner_backend.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    [DbContext(typeof(FSIPlannerDbContext))]
    partial class FSIPlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Assets", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Balance")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bucket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Custodian")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaturityDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RateOfReturn")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxStructure")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValuationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("AssetId");

                    b.HasIndex("UserId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Balance", b =>
                {
                    b.Property<int>("BalanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type10")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type11")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type12")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type13")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type14")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type15")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type16")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type17")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type18")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type19")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type2")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type20")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type21")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type22")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type3")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type4")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type5")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type6")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type7")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type8")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Type9")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("BalanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.BucketSummary", b =>
                {
                    b.Property<int>("BucketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bucket")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("BucketId");

                    b.HasIndex("UserId");

                    b.ToTable("BucketSummary");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Demographics", b =>
                {
                    b.Property<int>("DemographicsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("C1")
                        .HasColumnType("TEXT");

                    b.Property<string>("C2")
                        .HasColumnType("TEXT");

                    b.Property<string>("C3")
                        .HasColumnType("TEXT");

                    b.Property<string>("C4")
                        .HasColumnType("TEXT");

                    b.Property<string>("DriversLicense")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Employer")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Occupation")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialSecurity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Spouse")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkPhone")
                        .HasColumnType("TEXT");

                    b.HasKey("DemographicsId");

                    b.HasIndex("UserId");

                    b.ToTable("Demographics");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.DisabilityInsurance", b =>
                {
                    b.Property<int>("DisabilityInsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BenefitPeriod")
                        .HasColumnType("TEXT");

                    b.Property<string>("CashValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("EliminationPeriod")
                        .HasColumnType("TEXT");

                    b.Property<string>("Insured")
                        .HasColumnType("TEXT");

                    b.Property<string>("MonthlyDeathBenefitOne")
                        .HasColumnType("TEXT");

                    b.Property<string>("MonthlyDeathBenefitTwo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Premium")
                        .HasColumnType("TEXT");

                    b.Property<string>("Riders")
                        .HasColumnType("TEXT");

                    b.Property<string>("RidersBenefit")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("DisabilityInsId");

                    b.HasIndex("UserId");

                    b.ToTable("DisabilityIns");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Liabilities", b =>
                {
                    b.Property<int>("LiabilitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Payment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Term")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("LiabilitiesId");

                    b.HasIndex("UserId");

                    b.ToTable("Liabilites");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Life", b =>
                {
                    b.Property<int>("LifeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CashValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeathBenefitOne")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeathBenefitTwo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Insured")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercentageToSavings")
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Premium")
                        .HasColumnType("TEXT");

                    b.Property<string>("Riders")
                        .HasColumnType("TEXT");

                    b.Property<string>("RidersBenefit")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("LifeId");

                    b.HasIndex("UserId");

                    b.ToTable("Life");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.Notes", b =>
                {
                    b.Property<int>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NotesId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.PC", b =>
                {
                    b.Property<int>("PCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Deductible")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LiabilityLimit")
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Premium")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("PCId");

                    b.HasIndex("UserId");

                    b.ToTable("PC");
                });

            modelBuilder.Entity("fsiplanner_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
