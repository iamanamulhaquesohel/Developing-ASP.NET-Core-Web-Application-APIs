using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evidence_1264855.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(maxLength: 50, nullable: false),
                    BranchAddress = table.Column<string>(maxLength: 100, nullable: false),
                    BranchEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePicture = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeePhone = table.Column<string>(maxLength: 20, nullable: false),
                    EmployeeSalary = table.Column<decimal>(type: "money", nullable: false),
                    EmployeeDepartment = table.Column<string>(nullable: false),
                    EmployeeJoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeGender = table.Column<string>(nullable: false),
                    Continued = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
