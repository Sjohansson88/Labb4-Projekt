﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUT23_Labb4.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });
        }
    }
}
