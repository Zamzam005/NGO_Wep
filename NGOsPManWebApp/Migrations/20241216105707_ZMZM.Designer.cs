﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NGOsPManWebApp.Data;

#nullable disable

namespace NGOsPManWebApp.Migrations
{
    [DbContext(typeof(WebDbContext))]
    [Migration("20241216105707_ZMZM")]
    partial class ZMZM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NGOsPManWebApp.Models.Donor", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Don_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Don_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Don_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("DonorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("tbl_Donor");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emp_FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeId");

                    b.ToTable("tbl_employee");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Expense_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ExpenseId");

                    b.HasIndex("ProjectId");

                    b.ToTable("tbl_Expense");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Project_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("tbl_Project");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Ttask", b =>
                {
                    b.Property<int>("TtaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TtaskId"));

                    b.Property<DateTime>("Due_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TtaskId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("tbl_Tasks");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Donor", b =>
                {
                    b.HasOne("NGOsPManWebApp.Models.Project", "Project")
                        .WithMany("Donor")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Expense", b =>
                {
                    b.HasOne("NGOsPManWebApp.Models.Project", "Project")
                        .WithMany("Expense")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Ttask", b =>
                {
                    b.HasOne("NGOsPManWebApp.Models.Employee", "Employee")
                        .WithMany("Ttask")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGOsPManWebApp.Models.Project", "Project")
                        .WithMany("Ttask")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Employee", b =>
                {
                    b.Navigation("Ttask");
                });

            modelBuilder.Entity("NGOsPManWebApp.Models.Project", b =>
                {
                    b.Navigation("Donor");

                    b.Navigation("Expense");

                    b.Navigation("Ttask");
                });
#pragma warning restore 612, 618
        }
    }
}
