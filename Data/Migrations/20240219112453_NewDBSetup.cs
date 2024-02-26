using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidtabell.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDBSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Line");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "LineStops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Reverse",
                table: "Line",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "LineStops");

            migrationBuilder.DropColumn(
                name: "Reverse",
                table: "Line");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Line",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
