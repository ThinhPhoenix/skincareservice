using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareDAO.Migrations
{
    /// <inheritdoc />
    public partial class FixServiceFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHistories_Staff_ChangedBy",
                table: "AppointmentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staff_CreatedBy",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staff_ModifiedBy",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_CenterLocations_Staff_ManagerId",
                table: "CenterLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Staff_ProcessedBy",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Staff_CreatedBy",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Users_UserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequests_Staff_ApprovedBy",
                table: "TimeOffRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequests_Staff_StaffId",
                table: "TimeOffRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Staff_PerformedBy",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSchedules_Staff_StaffId",
                table: "WorkingSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_UserId",
                table: "Staffs",
                newName: "IX_Staffs_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHistories_Staffs_ChangedBy",
                table: "AppointmentHistories",
                column: "ChangedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staffs_CreatedBy",
                table: "Appointments",
                column: "CreatedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staffs_ModifiedBy",
                table: "Appointments",
                column: "ModifiedBy",
                principalTable: "Staffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterLocations_Staffs_ManagerId",
                table: "CenterLocations",
                column: "ManagerId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Staffs_ProcessedBy",
                table: "Payments",
                column: "ProcessedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Staffs_CreatedBy",
                table: "Promotions",
                column: "CreatedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequests_Staffs_ApprovedBy",
                table: "TimeOffRequests",
                column: "ApprovedBy",
                principalTable: "Staffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequests_Staffs_StaffId",
                table: "TimeOffRequests",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Staffs_PerformedBy",
                table: "Treatments",
                column: "PerformedBy",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSchedules_Staffs_StaffId",
                table: "WorkingSchedules",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHistories_Staffs_ChangedBy",
                table: "AppointmentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staffs_CreatedBy",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staffs_ModifiedBy",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_CenterLocations_Staffs_ManagerId",
                table: "CenterLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Staffs_ProcessedBy",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Staffs_CreatedBy",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequests_Staffs_ApprovedBy",
                table: "TimeOffRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequests_Staffs_StaffId",
                table: "TimeOffRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Staffs_PerformedBy",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSchedules_Staffs_StaffId",
                table: "WorkingSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_UserId",
                table: "Staff",
                newName: "IX_Staff_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Services",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHistories_Staff_ChangedBy",
                table: "AppointmentHistories",
                column: "ChangedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staff_CreatedBy",
                table: "Appointments",
                column: "CreatedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staff_ModifiedBy",
                table: "Appointments",
                column: "ModifiedBy",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterLocations_Staff_ManagerId",
                table: "CenterLocations",
                column: "ManagerId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Staff_ProcessedBy",
                table: "Payments",
                column: "ProcessedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Staff_CreatedBy",
                table: "Promotions",
                column: "CreatedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Users_UserId",
                table: "Staff",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequests_Staff_ApprovedBy",
                table: "TimeOffRequests",
                column: "ApprovedBy",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequests_Staff_StaffId",
                table: "TimeOffRequests",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Staff_PerformedBy",
                table: "Treatments",
                column: "PerformedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSchedules_Staff_StaffId",
                table: "WorkingSchedules",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
