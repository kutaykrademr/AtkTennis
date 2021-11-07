using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class allupd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "cabinetTypes");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "cabinetTypes");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "cabinetOperations");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "cabinetOperations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "cabinetTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "cabinetTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "cabinetOperations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "cabinetOperations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
