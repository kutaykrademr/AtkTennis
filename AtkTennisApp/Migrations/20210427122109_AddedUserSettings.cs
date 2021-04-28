using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class AddedUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_courts_courtsCourtId",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "courtsCourtId",
                table: "reservations",
                newName: "CourtsCourtId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_courtsCourtId",
                table: "reservations",
                newName: "IX_reservations_CourtsCourtId");

            migrationBuilder.CreateTable(
                name: "userSettings",
                columns: table => new
                {
                    UserSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advisory = table.Column<bool>(type: "bit", nullable: false),
                    Reservations = table.Column<bool>(type: "bit", nullable: false),
                    DebtandPayment = table.Column<bool>(type: "bit", nullable: false),
                    System = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userSettings", x => x.UserSettingsId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_courts_CourtsCourtId",
                table: "reservations",
                column: "CourtsCourtId",
                principalTable: "courts",
                principalColumn: "CourtId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_courts_CourtsCourtId",
                table: "reservations");

            migrationBuilder.DropTable(
                name: "userSettings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reservations",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CourtsCourtId",
                table: "reservations",
                newName: "courtsCourtId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_CourtsCourtId",
                table: "reservations",
                newName: "IX_reservations_courtsCourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_courts_courtsCourtId",
                table: "reservations",
                column: "courtsCourtId",
                principalTable: "courts",
                principalColumn: "CourtId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
