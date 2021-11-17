using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations.AppIdentityDb
{
    public partial class upd_identityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetRoles");
        }
    }
}
