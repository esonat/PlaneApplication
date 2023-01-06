using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneApplication.Data.Migrations
{
    public partial class addedCreatorIdToPlane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Plane",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Plane");
        }
    }
}
