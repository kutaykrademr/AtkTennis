using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class memberDuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memberDuesInfTables",
                columns: table => new
                {
                    MemberDuesInfTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuesYear = table.Column<int>(type: "int", nullable: false),
                    DuesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuesPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberDuesInfTables", x => x.MemberDuesInfTableId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberDuesInfTables");
        }
    }
}
