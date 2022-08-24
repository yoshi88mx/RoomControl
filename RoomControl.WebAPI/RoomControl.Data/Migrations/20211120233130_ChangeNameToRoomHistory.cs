using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class ChangeNameToRoomHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomMovements");

            migrationBuilder.CreateTable(
                name: "RoomHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdRoomState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomHistory_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomHistory_RoomStates_IdRoomState",
                        column: x => x.IdRoomState,
                        principalTable: "RoomStates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomHistory_IdRoom",
                table: "RoomHistory",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_RoomHistory_IdRoomState",
                table: "RoomHistory",
                column: "IdRoomState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomHistory");

            migrationBuilder.CreateTable(
                name: "RoomMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdRoomState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomMovements_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomMovements_RoomStates_IdRoomState",
                        column: x => x.IdRoomState,
                        principalTable: "RoomStates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMovements_IdRoom",
                table: "RoomMovements",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMovements_IdRoomState",
                table: "RoomMovements",
                column: "IdRoomState");
        }
    }
}
