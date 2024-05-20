using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SUT23_Labb4.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    OldStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, "Neptunuskliniken" },
                    { 2, "Breareds vårdcentral" },
                    { 3, "Wim Hof Terapi" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "ake@example.com", "Åke Svanstedt" },
                    { 2, "bjorn@example.com", "Björn Goop" },
                    { 3, "stig@example.com", "Stig H Johansson" },
                    { 4, "erik@example.com", "Erik Adielsson" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "EndTime", "Id", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2024, 5, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 5, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, new DateTime(2024, 5, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 5, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 3, new DateTime(2024, 5, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 5, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 4, new DateTime(2024, 5, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 5, 27, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompanyId",
                table: "Appointments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BookingHistories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
