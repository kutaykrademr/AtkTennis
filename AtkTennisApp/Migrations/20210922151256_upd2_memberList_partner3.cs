using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class upd2_memberList_partner3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailAddres",
                table: "memberLists",
                newName: "ReferenceMember2");

            migrationBuilder.AddColumn<string>(
                name: "DetailAddress",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceMember1",
                table: "memberLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailAddress",
                table: "memberLists");

            migrationBuilder.DropColumn(
                name: "ReferenceMember1",
                table: "memberLists");

            migrationBuilder.RenameColumn(
                name: "ReferenceMember2",
                table: "memberLists",
                newName: "DetailAddres");
        }
    }
}
