using Microsoft.EntityFrameworkCore.Migrations;

namespace AtkTennisApp.Migrations
{
    public partial class added_memberList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memberLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebReservation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Exp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailExp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberLists");
        }
    }
}
