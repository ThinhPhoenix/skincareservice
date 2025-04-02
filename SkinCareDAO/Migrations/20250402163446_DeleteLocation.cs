using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareDAO.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CenterLocations_LocationId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSchedules_CenterLocations_LocationId",
                table: "WorkingSchedules");

            migrationBuilder.DropTable(
                name: "CenterLocations");

            migrationBuilder.DropIndex(
                name: "IX_WorkingSchedules_LocationId",
                table: "WorkingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "WorkingSchedules");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "WorkingSchedules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CenterLocations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LocationName = table.Column<string>(type: "text", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterLocations_Staffs_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSchedules_LocationId",
                table: "WorkingSchedules",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterLocations_ManagerId",
                table: "CenterLocations",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CenterLocations_LocationId",
                table: "Appointments",
                column: "LocationId",
                principalTable: "CenterLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSchedules_CenterLocations_LocationId",
                table: "WorkingSchedules",
                column: "LocationId",
                principalTable: "CenterLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
