using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRater.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingFeedbacks");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    UserAnswers = table.Column<string>(type: "TEXT", nullable: true),
                    OverallRating = table.Column<string>(type: "TEXT", nullable: true),
                    EnvironmentalRating = table.Column<double>(type: "REAL", nullable: true),
                    SocialRating = table.Column<double>(type: "REAL", nullable: true),
                    EconomicRating = table.Column<double>(type: "REAL", nullable: true),
                    FutureRecommendations = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectFirmId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_ProjectFirms_ProjectFirmId",
                        column: x => x.ProjectFirmId,
                        principalTable: "ProjectFirms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProjectFirmId",
                table: "Ratings",
                column: "ProjectFirmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

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
