using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_cabinetTypesOp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinetOperations",
                columns: table => new
                {
                    CabinetOpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetOpTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetOpPrice = table.Column<int>(type: "int", nullable: false),
                    CabinetUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinetOperations", x => x.CabinetOpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cabinetOperations");
        }
    }
}
