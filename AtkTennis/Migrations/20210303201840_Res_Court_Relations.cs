using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennis.Migrations
{
    public partial class Res_Court_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "courtsCourtId",
                table: "reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_courtsCourtId",
                table: "reservations",
                column: "courtsCourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_courts_courtsCourtId",
                table: "reservations",
                column: "courtsCourtId",
                principalTable: "courts",
                principalColumn: "CourtId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_courts_courtsCourtId",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_courtsCourtId",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "courtsCourtId",
                table: "reservations");
        }
    }
}
