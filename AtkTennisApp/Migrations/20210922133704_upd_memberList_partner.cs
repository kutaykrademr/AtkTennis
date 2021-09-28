using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class upd_memberList_partner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "PartnerIdentityNumber",
                table: "memberLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartnerPhone",
                table: "memberLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isPartner",
                table: "memberLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PartnerPhone",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "isPartner",
                table: "memberLists");
        }
    }
}
