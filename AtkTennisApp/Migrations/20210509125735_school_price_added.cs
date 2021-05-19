using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class school_price_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "schoolLevels",
                newName: "Levels");

            migrationBuilder.RenameColumn(
                name: "QuotaInf",
                table: "schoolLevels",
                newName: "LevelId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "schoolTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "schoolPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    schoolTypeId = table.Column<int>(type: "int", nullable: false),
                    schoolLevelId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    priceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolPrices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schoolPrices");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "schoolTypes");

            migrationBuilder.RenameColumn(
                name: "Levels",
                table: "schoolLevels",
                newName: "Types");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "schoolLevels",
                newName: "QuotaInf");
        }
    }
}
