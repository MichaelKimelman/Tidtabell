using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidtabell.Data.Migrations
{
    /// <inheritdoc />
    public partial class LineStopStopPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StopPosition",
                table: "LineStops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StopPosition",
                table: "LineStops");
        }
    }
}
