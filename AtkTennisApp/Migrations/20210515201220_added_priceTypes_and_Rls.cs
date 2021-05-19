using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_priceTypes_and_Rls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceDescription",
                table: "schoolPrices");

            migrationBuilder.AddColumn<int>(
                name: "schoolPriceTypeId",
                table: "schoolPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "schoolPriceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolPriceTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schoolPrices_schoolPriceTypeId",
                table: "schoolPrices",
                column: "schoolPriceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_schoolPrices_schoolPriceTypes_schoolPriceTypeId",
                table: "schoolPrices",
                column: "schoolPriceTypeId",
                principalTable: "schoolPriceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schoolPrices_schoolPriceTypes_schoolPriceTypeId",
                table: "schoolPrices");

            migrationBuilder.DropTable(
                name: "schoolPriceTypes");

            migrationBuilder.DropIndex(
                name: "IX_schoolPrices_schoolPriceTypeId",
                table: "schoolPrices");

            migrationBuilder.DropColumn(
                name: "schoolPriceTypeId",
                table: "schoolPrices");

            migrationBuilder.AddColumn<string>(
                name: "priceDescription",
                table: "schoolPrices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
