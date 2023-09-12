using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRater.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSustainabilityAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SustainabilityAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Industry = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessNature = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessSize = table.Column<string>(type: "TEXT", nullable: true),
                    OperationalRegions = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturingInvolved = table.Column<bool>(type: "INTEGER", nullable: true),
                    SourcingFromOutside = table.Column<bool>(type: "INTEGER", nullable: true),
                    SourcingType = table.Column<string>(type: "TEXT", nullable: true),
                    ImpactOnLandUse = table.Column<bool>(type: "INTEGER", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "INTEGER", nullable: true),
                    PreviousSustainabilityInitiatives = table.Column<bool>(type: "INTEGER", nullable: true),
                    ProduceEmissionsOrWaste = table.Column<bool>(type: "INTEGER", nullable: true),
                    ProjectFirmId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SustainabilityAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SustainabilityAssessments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SustainabilityAssessments_ProjectFirms_ProjectFirmId",
                        column: x => x.ProjectFirmId,
                        principalTable: "ProjectFirms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SustainabilityAssessments_ProjectFirmId",
                table: "SustainabilityAssessments",
                column: "ProjectFirmId");

            migrationBuilder.CreateIndex(
                name: "IX_SustainabilityAssessments_UserId",
                table: "SustainabilityAssessments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SustainabilityAssessments");
        }
    }
}
