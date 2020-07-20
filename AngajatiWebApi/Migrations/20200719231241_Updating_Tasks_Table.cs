using Microsoft.EntityFrameworkCore.Migrations;

namespace AngajatiWebApi.Migrations
{
    public partial class Updating_Tasks_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Tasks",
                maxLength: 2500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: true);
        }
    }
}
