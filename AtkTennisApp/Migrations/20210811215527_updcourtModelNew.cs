using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class updcourtModelNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courtTimeInfs");

            migrationBuilder.DropTable(
                name: "courtTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courtTimeInfs",
                columns: table => new
                {
                    CourtTimeInfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtFinishTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    CourtStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtTimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courtTimeInfs", x => x.CourtTimeInfId);
                });

            migrationBuilder.CreateTable(
                name: "courtTypes",
                columns: table => new
                {
                    CourtTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courtTypes", x => x.CourtTypesId);
                });
        }
    }
}
