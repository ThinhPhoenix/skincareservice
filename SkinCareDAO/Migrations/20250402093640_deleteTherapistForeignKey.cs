using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareDAO.Migrations
{
    /// <inheritdoc />
    public partial class deleteTherapistForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkinAssessments_Therapists_TherapistId",
                table: "SkinAssessments");

            migrationBuilder.DropIndex(
                name: "IX_SkinAssessments_TherapistId",
                table: "SkinAssessments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SkinAssessments_TherapistId",
                table: "SkinAssessments",
                column: "TherapistId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkinAssessments_Therapists_TherapistId",
                table: "SkinAssessments",
                column: "TherapistId",
                principalTable: "Therapists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
