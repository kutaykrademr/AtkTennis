using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class upd_memberList_new_PartnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerBirthDate",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "PartnerFullName",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "PartnerIdentityNumber",
                table: "memberLists");

            migrationBuilder.RenameColumn(
                name: "PartnerPhone",
                table: "memberLists",
                newName: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "memberLists",
                newName: "PartnerPhone");

            migrationBuilder.AddColumn<string>(
                name: "PartnerBirthDate",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerFullName",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerIdentityNumber",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
