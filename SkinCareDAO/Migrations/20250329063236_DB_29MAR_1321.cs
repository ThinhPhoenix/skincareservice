using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareDAO.Migrations
{
    /// <inheritdoc />
    public partial class DB_29MAR_1321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    QuestionType = table.Column<string>(type: "text", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Prerequisites = table.Column<string>(type: "text", nullable: false),
                    Aftercare = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentOption",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<string>(type: "text", nullable: false),
                    OptionText = table.Column<string>(type: "text", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentOption_AssessmentQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AssessmentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceToCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceToCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceToCategories_ServiceCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceToCategories_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsManager = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Expertise = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: false),
                    WorkStartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    WorkEndTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseServiceMappings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    RelevanceScore = table.Column<int>(type: "integer", nullable: false),
                    Contraindication = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseServiceMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseServiceMappings_AssessmentOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "AssessmentOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseServiceMappings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CenterLocations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LocationName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterLocations_Staff_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PromotionName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Staff_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkinAssessments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    AssessmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SkinType = table.Column<string>(type: "text", nullable: false),
                    Concerns = table.Column<string>(type: "text", nullable: false),
                    Allergies = table.Column<string>(type: "text", nullable: false),
                    ProductsUsed = table.Column<string>(type: "text", nullable: false),
                    Medications = table.Column<string>(type: "text", nullable: false),
                    Recommendations = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkinAssessments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkinAssessments_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistExpertises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "integer", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistExpertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistExpertises_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TherapistExpertises_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeOffRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StaffId = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestStatus = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOffRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeOffRequests_Staff_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeOffRequests_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeOffRequests_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    LocationId = table.Column<string>(type: "text", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_CenterLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "CenterLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StaffId = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false),
                    LocationId = table.Column<string>(type: "text", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduleType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSchedules_CenterLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "CenterLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSchedules_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSchedules_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePromotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PromotionId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePromotions_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePromotions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentResponses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AssessmentId = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<string>(type: "text", nullable: false),
                    ResponseText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentResponses_AssessmentOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "AssessmentOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentResponses_AssessmentQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AssessmentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentResponses_SkinAssessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "SkinAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecommendations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AssessmentId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    RecommendationStrength = table.Column<string>(type: "text", nullable: false),
                    RecommendationReason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRecommendations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRecommendations_SkinAssessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "SkinAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppointmentId = table.Column<string>(type: "text", nullable: false),
                    PreviousStatus = table.Column<string>(type: "text", nullable: false),
                    NewStatus = table.Column<string>(type: "text", nullable: false),
                    ChangeDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangedBy = table.Column<string>(type: "text", nullable: false),
                    ChangeReason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentHistories_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentHistories_Staff_ChangedBy",
                        column: x => x.ChangedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppointmentId = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    TherapistId = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsAddressed = table.Column<bool>(type: "boolean", nullable: false),
                    StaffResponse = table.Column<string>(type: "text", nullable: false),
                    ResponseDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppointmentId = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    TransactionReference = table.Column<string>(type: "text", nullable: false),
                    ProcessedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Staff_ProcessedBy",
                        column: x => x.ProcessedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppointmentId = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ProductsUsed = table.Column<string>(type: "text", nullable: false),
                    Results = table.Column<string>(type: "text", nullable: false),
                    AftercareInstructions = table.Column<string>(type: "text", nullable: false),
                    FollowUpRecommendations = table.Column<string>(type: "text", nullable: false),
                    PerformedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Staff_PerformedBy",
                        column: x => x.PerformedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistories_AppointmentId",
                table: "AppointmentHistories",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistories_ChangedBy",
                table: "AppointmentHistories",
                column: "ChangedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CreatedBy",
                table: "Appointments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ModifiedBy",
                table: "Appointments",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TherapistId",
                table: "Appointments",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentOption_QuestionId",
                table: "AssessmentOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResponses_AssessmentId",
                table: "AssessmentResponses",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResponses_OptionId",
                table: "AssessmentResponses",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResponses_QuestionId",
                table: "AssessmentResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterLocations_ManagerId",
                table: "CenterLocations",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AppointmentId",
                table: "Feedbacks",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ServiceId",
                table: "Feedbacks",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TherapistId",
                table: "Feedbacks",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProcessedBy",
                table: "Payments",
                column: "ProcessedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CreatedBy",
                table: "Promotions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseServiceMappings_OptionId",
                table: "ResponseServiceMappings",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseServiceMappings_ServiceId",
                table: "ResponseServiceMappings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePromotions_PromotionId",
                table: "ServicePromotions",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePromotions_ServiceId",
                table: "ServicePromotions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecommendations_AssessmentId",
                table: "ServiceRecommendations",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecommendations_ServiceId",
                table: "ServiceRecommendations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceToCategories_CategoryId",
                table: "ServiceToCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceToCategories_ServiceId",
                table: "ServiceToCategories",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinAssessments_CustomerId",
                table: "SkinAssessments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinAssessments_TherapistId",
                table: "SkinAssessments",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserId",
                table: "Staff",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistExpertises_ServiceId",
                table: "TherapistExpertises",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistExpertises_TherapistId",
                table: "TherapistExpertises",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_UserId",
                table: "Therapists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffRequests_ApprovedBy",
                table: "TimeOffRequests",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffRequests_StaffId",
                table: "TimeOffRequests",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffRequests_TherapistId",
                table: "TimeOffRequests",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AppointmentId",
                table: "Treatments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PerformedBy",
                table: "Treatments",
                column: "PerformedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSchedules_LocationId",
                table: "WorkingSchedules",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSchedules_StaffId",
                table: "WorkingSchedules",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSchedules_TherapistId",
                table: "WorkingSchedules",
                column: "TherapistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentHistories");

            migrationBuilder.DropTable(
                name: "AssessmentResponses");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResponseServiceMappings");

            migrationBuilder.DropTable(
                name: "ServicePromotions");

            migrationBuilder.DropTable(
                name: "ServiceRecommendations");

            migrationBuilder.DropTable(
                name: "ServiceToCategories");

            migrationBuilder.DropTable(
                name: "TherapistExpertises");

            migrationBuilder.DropTable(
                name: "TimeOffRequests");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "WorkingSchedules");

            migrationBuilder.DropTable(
                name: "AssessmentOption");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "SkinAssessments");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "CenterLocations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);
        }
    }
}
