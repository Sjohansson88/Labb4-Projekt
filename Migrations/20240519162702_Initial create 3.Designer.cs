﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUT23_Labb4.Data;

#nullable disable

namespace SUT23_Labb4.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20240519162702_Initial create 3")]
    partial class Initialcreate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SUT23_Labb4Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            CompanyId = 1,
                            CustomerId = 1,
                            EndTime = new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 2,
                            CompanyId = 2,
                            CustomerId = 2,
                            EndTime = new DateTime(2024, 5, 16, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 16, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 3,
                            CompanyId = 1,
                            CustomerId = 1,
                            EndTime = new DateTime(2024, 5, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 25, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 4,
                            CompanyId = 3,
                            CustomerId = 3,
                            EndTime = new DateTime(2024, 5, 26, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 26, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 5,
                            CompanyId = 2,
                            CustomerId = 4,
                            EndTime = new DateTime(2024, 5, 27, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 27, 14, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SUT23_Labb4Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Name = "Neptunuskliniken"
                        },
                        new
                        {
                            CompanyId = 2,
                            Name = "Breareds vårdcentral"
                        },
                        new
                        {
                            CompanyId = 3,
                            Name = "Wim Hof Terapi"
                        });
                });

            modelBuilder.Entity("SUT23_Labb4Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "ake@example.com",
                            Name = "Åke Svanstedt"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "bjorn@example.com",
                            Name = "Björn Goop"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "stig@example.com",
                            Name = "Stig H Johansson"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "erik@example.com",
                            Name = "Erik Adielsson"
                        });
                });

            modelBuilder.Entity("SUT23_Labb4Models.Appointment", b =>
                {
                    b.HasOne("SUT23_Labb4Models.Company", "Company")
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23_Labb4Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SUT23_Labb4Models.Company", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("SUT23_Labb4Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
