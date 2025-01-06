using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NGOsPManWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ZMZM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Join_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Donor",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Don_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Don_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Don_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Donor", x => x.DonorId);
                    table.ForeignKey(
                        name: "FK_tbl_Donor_tbl_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tbl_Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expense_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_tbl_Expense_tbl_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tbl_Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tasks",
                columns: table => new
                {
                    TtaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tasks", x => x.TtaskId);
                    table.ForeignKey(
                        name: "FK_tbl_Tasks_tbl_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tbl_Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Tasks_tbl_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tbl_employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Donor_ProjectId",
                table: "tbl_Donor",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Expense_ProjectId",
                table: "tbl_Expense",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_EmployeeId",
                table: "tbl_Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_ProjectId",
                table: "tbl_Tasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Donor");

            migrationBuilder.DropTable(
                name: "tbl_Expense");

            migrationBuilder.DropTable(
                name: "tbl_Tasks");

            migrationBuilder.DropTable(
                name: "tbl_Project");

            migrationBuilder.DropTable(
                name: "tbl_employee");
        }
    }
}
