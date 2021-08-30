using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class updCabListOpModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinetListUsers",
                columns: table => new
                {
                    CabinetOpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetOpTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetOpPrice = table.Column<int>(type: "int", nullable: false),
                    CabinetWho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinetListUsers", x => x.CabinetOpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cabinetListUsers");
        }
    }
}
