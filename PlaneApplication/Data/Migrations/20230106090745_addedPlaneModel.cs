using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneApplication.Data.Migrations
{
    public partial class addedPlaneModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneType = table.Column<int>(type: "int", nullable: false),
                    PlanePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneYear = table.Column<int>(type: "int", nullable: false),
                    PlaneManifacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneOwner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.PlaneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plane");
        }
    }
}
