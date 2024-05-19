using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SUT23_Labb4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "EndTime", "StartTime" },
                values: new object[] { 3, 1, 1, new DateTime(2024, 5, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[] { 3, "Wim Hof Terapi" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 3, "stig@example.com", "Stig H Johansson" },
                    { 4, "erik@example.com", "Erik Adielsson" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 4, 3, 3, new DateTime(2024, 5, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 4, new DateTime(2024, 5, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);
        }
    }
}
