using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_privateLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PerQuotaInf",
                table: "performanceLevels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "privateLessons",
                columns: table => new
                {
                    PrivateLessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffeInf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateLessonPrice = table.Column<int>(type: "int", nullable: true),
                    TeacherPrice = table.Column<int>(type: "int", nullable: true),
                    PrivateLessonType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privateLessons", x => x.PrivateLessonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "privateLessons");

            migrationBuilder.AlterColumn<int>(
                name: "PerQuotaInf",
                table: "performanceLevels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
