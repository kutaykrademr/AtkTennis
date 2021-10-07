using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class memberDuesInfTable_upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaidPrice",
                table: "memberDuesInfTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingPrice",
                table: "memberDuesInfTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidPrice",
                table: "memberDuesInfTables");

            migrationBuilder.DropColumn(
                name: "RemainingPrice",
                table: "memberDuesInfTables");
        }
    }
}
