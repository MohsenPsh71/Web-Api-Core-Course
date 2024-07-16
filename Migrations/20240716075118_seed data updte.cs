using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api_Core_Course.Migrations
{
    /// <inheritdoc />
    public partial class seeddataupdte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Academy mohsenpsh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Academy Barnamenevisan");
        }
    }
}
