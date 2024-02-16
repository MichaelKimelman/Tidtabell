using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidtabell.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTime1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClockTime",
                table: "Time");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Time",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "Time",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockTime",
                table: "Time",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
