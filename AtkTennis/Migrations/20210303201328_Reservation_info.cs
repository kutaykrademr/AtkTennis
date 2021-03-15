using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennis.Migrations
{
    public partial class Reservation_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ResId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResFinishTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResEvent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ResId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
