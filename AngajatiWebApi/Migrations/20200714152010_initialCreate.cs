using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngajatiWebApi.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TrainingName = table.Column<string>(maxLength: 150, nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    LastName = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TaskName = table.Column<string>(maxLength: 150, nullable: false),
                    TrainingId = table.Column<Guid>(nullable: false),
                    PayPerHour = table.Column<double>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timekeepings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    Stop = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(maxLength: 150, nullable: false),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timekeepings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Timekeepings_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timekeepings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TrainingId",
                table: "Tasks",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Timekeepings_TaskId",
                table: "Timekeepings",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Timekeepings_UserId",
                table: "Timekeepings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timekeepings");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
