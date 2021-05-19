using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class CourtPriceRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "schoolTypes");

            migrationBuilder.DropColumn(
                name: "schoolTypeId",
                table: "schoolPrices");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "schoolLevels");

            migrationBuilder.RenameColumn(
                name: "schoolLevelId",
                table: "schoolPrices",
                newName: "SchoolLevelId");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolLevelId",
                table: "schoolPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SchoolTypesId",
                table: "schoolPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_schoolPrices_SchoolLevelId",
                table: "schoolPrices",
                column: "SchoolLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_schoolPrices_SchoolTypesId",
                table: "schoolPrices",
                column: "SchoolTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_schoolPrices_schoolLevels_SchoolLevelId",
                table: "schoolPrices",
                column: "SchoolLevelId",
                principalTable: "schoolLevels",
                principalColumn: "SchoolLevelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schoolPrices_schoolTypes_SchoolTypesId",
                table: "schoolPrices",
                column: "SchoolTypesId",
                principalTable: "schoolTypes",
                principalColumn: "SchoolTypesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schoolPrices_schoolLevels_SchoolLevelId",
                table: "schoolPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_schoolPrices_schoolTypes_SchoolTypesId",
                table: "schoolPrices");

            migrationBuilder.DropIndex(
                name: "IX_schoolPrices_SchoolLevelId",
                table: "schoolPrices");

            migrationBuilder.DropIndex(
                name: "IX_schoolPrices_SchoolTypesId",
                table: "schoolPrices");

            migrationBuilder.DropColumn(
                name: "SchoolTypesId",
                table: "schoolPrices");

            migrationBuilder.RenameColumn(
                name: "SchoolLevelId",
                table: "schoolPrices",
                newName: "schoolLevelId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "schoolTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "schoolLevelId",
                table: "schoolPrices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "schoolTypeId",
                table: "schoolPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "schoolLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
