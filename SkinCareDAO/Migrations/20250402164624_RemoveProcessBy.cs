using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareDAO.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProcessBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Staffs_ProcessedBy",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ProcessedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProcessedBy",
                table: "Payments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessedBy",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProcessedBy",
                table: "Payments",
                column: "ProcessedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Staffs_ProcessedBy",
                table: "Payments",
                column: "ProcessedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
