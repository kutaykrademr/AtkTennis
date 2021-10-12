using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class update_priceListCourt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayInf",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthInf",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeInf",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayInf",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "MonthInf",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "TimeInf",
                table: "courtPriceLists");
        }
    }
}
