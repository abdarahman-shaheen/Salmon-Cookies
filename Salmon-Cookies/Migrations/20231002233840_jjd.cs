using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salmon_Cookies.Migrations
{
    /// <inheritdoc />
    public partial class jjd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false),
                    CookieStandid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourSales_CookieStands_CookieStandid",
                        column: x => x.CookieStandid,
                        principalTable: "CookieStands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourSales_CookieStandid",
                table: "HourSales",
                column: "CookieStandid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourSales");

            migrationBuilder.DropTable(
                name: "CookieStands");
        }
    }
}
