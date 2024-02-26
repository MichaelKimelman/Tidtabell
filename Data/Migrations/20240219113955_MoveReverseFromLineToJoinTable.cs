using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidtabell.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoveReverseFromLineToJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reverse",
                table: "Line");

            migrationBuilder.AddColumn<bool>(
                name: "Reverse",
                table: "LineStops",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reverse",
                table: "LineStops");

            migrationBuilder.AddColumn<bool>(
                name: "Reverse",
                table: "Line",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
