using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class RemoveIdRoomFromDisplayHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisplayHistoryes_Rooms_IdRoom",
                table: "DisplayHistoryes");

            migrationBuilder.DropIndex(
                name: "IX_DisplayHistoryes_IdRoom",
                table: "DisplayHistoryes");

            migrationBuilder.DropColumn(
                name: "IdRoom",
                table: "DisplayHistoryes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRoom",
                table: "DisplayHistoryes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DisplayHistoryes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdRoom",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DisplayHistoryes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdRoom",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DisplayHistoryes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdRoom",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_DisplayHistoryes_IdRoom",
                table: "DisplayHistoryes",
                column: "IdRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_DisplayHistoryes_Rooms_IdRoom",
                table: "DisplayHistoryes",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
