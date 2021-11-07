using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class allupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "userSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "resTimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "reservationSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "reservationCancels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "reservationCancels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "reservationCancels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "memberDuesTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "memberDuesInfTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "memberDuesInfTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "memberDuesInfTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "memberDebtTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "courtScaleLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "courtRecipeTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "courtPriceLists",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "CompanyId",
                table: "cabinetTypes",
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
                name: "CompanyId",
                table: "cabinetOperations",
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

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "cabinetListUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "cabinetListUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "cabinetListUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "allGetPaidLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "allGetPaidLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "allGetPaidLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "userSettings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "resTimes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "reservationSettings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "reservationCancels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "reservationCancels");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "reservationCancels");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "memberDuesTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "memberDuesInfTables");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "memberDuesInfTables");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "memberDuesInfTables");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "memberDebtTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "courtScaleLists");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "courts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "courtRecipeTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "courtPriceLists");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "cabinetTypes");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "cabinetTypes");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "cabinetTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "cabinetOperations");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "cabinetOperations");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "cabinetOperations");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "cabinetListUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "cabinetListUsers");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "cabinetListUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "allGetPaidLogs");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "allGetPaidLogs");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "allGetPaidLogs");
        }
    }
}
