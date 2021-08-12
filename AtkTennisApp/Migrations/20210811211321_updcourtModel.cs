using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class updcourtModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourtFinishTime",
                table: "courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtStartTime",
                table: "courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtTimePeriod",
                table: "courts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourtFinishTime",
                table: "courts");

            migrationBuilder.DropColumn(
                name: "CourtStartTime",
                table: "courts");

            migrationBuilder.DropColumn(
                name: "CourtTimePeriod",
                table: "courts");
        }
    }
}
