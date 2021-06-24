using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class upd_userSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "System",
                table: "userSettings",
                newName: "SystemSettings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemSettings",
                table: "userSettings",
                newName: "System");
        }
    }
}
