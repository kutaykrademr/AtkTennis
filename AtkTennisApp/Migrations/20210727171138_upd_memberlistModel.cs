using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class upd_memberlistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "memberLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "memberLists");
        }
    }
}
