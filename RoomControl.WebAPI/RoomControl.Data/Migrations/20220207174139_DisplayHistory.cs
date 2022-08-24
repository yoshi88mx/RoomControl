using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class DisplayHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisplayHistoryes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdQueue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayHistoryes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisplayHistoryes_Queues_IdQueue",
                        column: x => x.IdQueue,
                        principalTable: "Queues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisplayHistoryes_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DisplayHistoryes",
                columns: new[] { "Id", "Date", "Description", "IdQueue", "IdRoom", "IsAvailable", "Number" },
                values: new object[] { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inicial", 1, 1, false, "" });

            migrationBuilder.InsertData(
                table: "DisplayHistoryes",
                columns: new[] { "Id", "Date", "Description", "IdQueue", "IdRoom", "IsAvailable", "Number" },
                values: new object[] { 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incial", 2, 2, false, "" });

            migrationBuilder.InsertData(
                table: "DisplayHistoryes",
                columns: new[] { "Id", "Date", "Description", "IdQueue", "IdRoom", "IsAvailable", "Number" },
                values: new object[] { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incial", 3, 4, false, "" });

            migrationBuilder.CreateIndex(
                name: "IX_DisplayHistoryes_IdQueue",
                table: "DisplayHistoryes",
                column: "IdQueue");

            migrationBuilder.CreateIndex(
                name: "IX_DisplayHistoryes_IdRoom",
                table: "DisplayHistoryes",
                column: "IdRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisplayHistoryes");
        }
    }
}
