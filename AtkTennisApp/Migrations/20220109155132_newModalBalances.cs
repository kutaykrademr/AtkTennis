using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class newModalBalances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balanceOpModels_memberLists_memberListId",
                table: "balanceOpModels");

            migrationBuilder.DropIndex(
                name: "IX_balanceOpModels_memberListId",
                table: "balanceOpModels");

            migrationBuilder.DropColumn(
                name: "memberListId",
                table: "balanceOpModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "memberListId",
                table: "balanceOpModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_balanceOpModels_memberListId",
                table: "balanceOpModels",
                column: "memberListId");

            migrationBuilder.AddForeignKey(
                name: "FK_balanceOpModels_memberLists_memberListId",
                table: "balanceOpModels",
                column: "memberListId",
                principalTable: "memberLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
