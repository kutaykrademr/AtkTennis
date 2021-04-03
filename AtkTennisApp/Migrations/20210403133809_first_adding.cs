using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class first_adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courtPriceLists",
                columns: table => new
                {
                    CourtPriceListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtPrice = table.Column<int>(type: "int", nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courtPriceLists", x => x.CourtPriceListId);
                });

            migrationBuilder.CreateTable(
                name: "courts",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtWebConditions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courts", x => x.CourtId);
                });

            migrationBuilder.CreateTable(
                name: "resTimes",
                columns: table => new
                {
                    ResTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResTimes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resTimes", x => x.ResTimeId);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ResId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResFinishTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courtsCourtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ResId);
                    table.ForeignKey(
                        name: "FK_reservations_courts_courtsCourtId",
                        column: x => x.courtsCourtId,
                        principalTable: "courts",
                        principalColumn: "CourtId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_courtsCourtId",
                table: "reservations",
                column: "courtsCourtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courtPriceLists");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "resTimes");

            migrationBuilder.DropTable(
                name: "courts");
        }
    }
}
