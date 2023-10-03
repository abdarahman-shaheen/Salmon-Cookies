using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salmon_Cookies.Migrations
{
    /// <inheritdoc />
    public partial class ds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sales",
                table: "HourSales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "HourSales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
