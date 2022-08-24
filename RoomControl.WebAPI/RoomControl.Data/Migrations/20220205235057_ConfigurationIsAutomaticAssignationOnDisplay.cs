using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomControl.Data.Migrations
{
    public partial class ConfigurationIsAutomaticAssignationOnDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutomaticAssignationOnDisplay",
                table: "GeneralConfiguration",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutomaticAssignationOnDisplay",
                table: "GeneralConfiguration");
        }
    }
}
