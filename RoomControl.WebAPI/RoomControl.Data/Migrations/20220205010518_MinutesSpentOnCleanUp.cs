using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class MinutesSpentOnCleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesSpentOnCleanUp",
                table: "Queues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Queues",
                keyColumn: "Id",
                keyValue: 1,
                column: "MinutesSpentOnCleanUp",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Queues",
                keyColumn: "Id",
                keyValue: 2,
                column: "MinutesSpentOnCleanUp",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Queues",
                keyColumn: "Id",
                keyValue: 3,
                column: "MinutesSpentOnCleanUp",
                value: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesSpentOnCleanUp",
                table: "Queues");
        }
    }
}
