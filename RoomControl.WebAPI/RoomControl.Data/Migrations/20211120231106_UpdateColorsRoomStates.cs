using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class UpdateColorsRoomStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomStates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "bg-success");

            migrationBuilder.UpdateData(
                table: "RoomStates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "bg-danger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomStates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "bg-info");

            migrationBuilder.UpdateData(
                table: "RoomStates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "bg-success");
        }
    }
}
