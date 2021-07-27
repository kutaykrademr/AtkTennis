using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_cancelresModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservationCancels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResId = table.Column<int>(type: "int", nullable: false),
                    ResDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResFinishTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResNowDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInf = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    PriceIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelRes = table.Column<bool>(type: "bit", nullable: false),
                    CancelResUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procedure = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationCancels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservationCancels");
        }
    }
}
