using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class allGetPaidLogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allGetPaidLogs",
                columns: table => new
                {
                    AllGetPaidLogsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoOpUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PaidPrice = table.Column<int>(type: "int", nullable: false),
                    RemainingPrice = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    ReceiptNo = table.Column<int>(type: "int", nullable: false),
                    ReceiptDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefType = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allGetPaidLogs", x => x.AllGetPaidLogsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allGetPaidLogs");
        }
    }
}
