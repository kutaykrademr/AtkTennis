using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennis.Migrations
{
    public partial class res_time_new_added2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resTimes",
                columns: table => new
                {
                    ResTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResTimes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resTimes", x => x.ResTimeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resTimes");
        }
    }
}
