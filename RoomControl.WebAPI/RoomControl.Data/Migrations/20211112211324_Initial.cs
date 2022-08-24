using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRoomStateOnQueue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ByHours = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdRoomType = table.Column<int>(type: "int", nullable: false),
                    IdRoomState = table.Column<int>(type: "int", nullable: false),
                    IdQueue = table.Column<int>(type: "int", nullable: false),
                    IdRoomPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Queues_IdQueue",
                        column: x => x.IdQueue,
                        principalTable: "Queues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomPrices_IdRoomPrice",
                        column: x => x.IdRoomPrice,
                        principalTable: "RoomPrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomStates_IdRoomState",
                        column: x => x.IdRoomState,
                        principalTable: "RoomStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_IdRoomType",
                        column: x => x.IdRoomType,
                        principalTable: "RoomTypes",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "GeneralConfiguration",
                columns: new[] { "Id", "IdRoomStateOnQueue" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Queues",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "Cola Sencilla" },
                    { 2, true, "Cola Completa" },
                    { 3, true, "Cola VIP" }
                });

            migrationBuilder.InsertData(
                table: "RoomPrices",
                columns: new[] { "Id", "ByHours", "Price" },
                values: new object[,]
                {
                    { 1, 4, 350.0 },
                    { 2, 12, 750.0 },
                    { 3, 24, 1200.0 }
                });

            migrationBuilder.InsertData(
                table: "RoomStates",
                columns: new[] { "Id", "Color", "Description", "Position" },
                values: new object[,]
                {
                    { 1, "bg-info", "Disponible", 1 },
                    { 2, "bg-success", "Ocupado", 2 },
                    { 3, "bg-warning", "Sucia", 3 },
                    { 4, "bg-secondary", "Mantenimiento", 0 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Sencilla" },
                    { 2, "Completa" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Active", "Description", "IdQueue", "IdRoomPrice", "IdRoomState", "IdRoomType", "Number" },
                values: new object[,]
                {
                    { 1, true, "Suite Junior 1", 1, 1, 1, 1, 1 },
                    { 2, true, "Suite Junior 2", 1, 1, 1, 1, 2 },
                    { 3, true, "Master con jacuzzi 1", 1, 1, 1, 2, 1 },
                    { 4, true, "Master con jacuzzi 2", 2, 1, 1, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMovements_IdRoom",
                table: "RoomMovements",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMovements_IdRoomState",
                table: "RoomMovements",
                column: "IdRoomState");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdQueue",
                table: "Rooms",
                column: "IdQueue");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdRoomPrice",
                table: "Rooms",
                column: "IdRoomPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdRoomState",
                table: "Rooms",
                column: "IdRoomState");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdRoomType",
                table: "Rooms",
                column: "IdRoomType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralConfiguration");

            migrationBuilder.DropTable(
                name: "RoomMovements");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "RoomPrices");

            migrationBuilder.DropTable(
                name: "RoomStates");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
