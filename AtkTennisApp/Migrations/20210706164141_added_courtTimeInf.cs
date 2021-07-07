using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_courtTimeInf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courtTimeInfs",
                columns: table => new
                {
                    CourtTimeInfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    CourtStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtFinishTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtTimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courtTimeInfs", x => x.CourtTimeInfId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courtTimeInfs");
        }
    }
}
