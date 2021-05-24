using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_courts_CourtsCourtId",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "CourtsCourtId",
                table: "reservations",
                newName: "CourtId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_CourtsCourtId",
                table: "reservations",
                newName: "IX_reservations_CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_courts_CourtId",
                table: "reservations",
                column: "CourtId",
                principalTable: "courts",
                principalColumn: "CourtId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_courts_CourtId",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "CourtId",
                table: "reservations",
                newName: "CourtsCourtId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_CourtId",
                table: "reservations",
                newName: "IX_reservations_CourtsCourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_courts_CourtsCourtId",
                table: "reservations",
                column: "CourtsCourtId",
                principalTable: "courts",
                principalColumn: "CourtId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
