using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityApp.Migrations
{
    public partial class upd_memList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompIp",
                table: "memberLİst",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompIp",
                table: "memberLİst");
        }
    }
}
