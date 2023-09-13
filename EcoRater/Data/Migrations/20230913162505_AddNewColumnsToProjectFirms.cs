using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRater.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnsToProjectFirms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingFeedbacks");

            migrationBuilder.AddColumn<string>(
                name: "BusinessNature",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessSize",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EconomicRating",
                table: "ProjectFirms",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EnvironmentalRating",
                table: "ProjectFirms",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FutureRecommendations",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ImpactOnLandUse",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ManufacturingInvolved",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployees",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationalRegions",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverallRating",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PreviousSustainabilityInitiatives",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProduceEmissionsOrWaste",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionsText",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SocialRating",
                table: "ProjectFirms",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SourcingFromOutside",
                table: "ProjectFirms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourcingType",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAnswers",
                table: "ProjectFirms",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessNature",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "BusinessSize",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "EconomicRating",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "EnvironmentalRating",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "FutureRecommendations",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "ImpactOnLandUse",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "ManufacturingInvolved",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "NumberOfEmployees",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "OperationalRegions",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "PreviousSustainabilityInitiatives",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "ProduceEmissionsOrWaste",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "QuestionsText",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "SocialRating",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "SourcingFromOutside",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "SourcingType",
                table: "ProjectFirms");

            migrationBuilder.DropColumn(
                name: "UserAnswers",
                table: "ProjectFirms");

            migrationBuilder.CreateTable(
                name: "RatingFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectFirmId = table.Column<int>(type: "INTEGER", nullable: true),
                    AIRecommendations = table.Column<string>(type: "TEXT", nullable: true),
                    AnswersToQuestions = table.Column<string>(type: "TEXT", nullable: true),
                    EconomicRating = table.Column<double>(type: "REAL", nullable: true),
                    EnvironmentalRating = table.Column<double>(type: "REAL", nullable: true),
                    SocialRating = table.Column<double>(type: "REAL", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingFeedbacks_ProjectFirms_ProjectFirmId",
                        column: x => x.ProjectFirmId,
                        principalTable: "ProjectFirms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingFeedbacks_ProjectFirmId",
                table: "RatingFeedbacks",
                column: "ProjectFirmId");
        }
    }
}
