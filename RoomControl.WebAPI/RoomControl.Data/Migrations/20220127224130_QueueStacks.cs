using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class QueueStacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdQueueStack",
                table: "Queues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QueueStacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdRoomState = table.Column<int>(type: "int", nullable: false),
                    IdQueue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueStacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueStacks_Queues_IdQueue",
                        column: x => x.IdQueue,
                        principalTable: "Queues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QueueStacks_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QueueStacks_RoomStates_IdRoomState",
                        column: x => x.IdRoomState,
                        principalTable: "RoomStates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QueueStacks_IdQueue",
                table: "QueueStacks",
                column: "IdQueue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueueStacks_IdRoom",
                table: "QueueStacks",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_QueueStacks_IdRoomState",
                table: "QueueStacks",
                column: "IdRoomState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueueStacks");

            migrationBuilder.DropColumn(
                name: "IdQueueStack",
                table: "Queues");
        }
    }
}
