using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRater.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectFirms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFirms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFirms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswersToQuestions = table.Column<string>(type: "TEXT", nullable: false),
                    EnvironmentalRating = table.Column<double>(type: "REAL", nullable: false),
                    SocialRating = table.Column<double>(type: "REAL", nullable: false),
                    EconomicRating = table.Column<double>(type: "REAL", nullable: false),
                    AIRecommendations = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProjectFirmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingFeedbacks_ProjectFirms_ProjectFirmId",
                        column: x => x.ProjectFirmId,
                        principalTable: "ProjectFirms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFirms_UserId",
                table: "ProjectFirms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingFeedbacks_ProjectFirmId",
                table: "RatingFeedbacks",
                column: "ProjectFirmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingFeedbacks");

            migrationBuilder.DropTable(
                name: "ProjectFirms");
        }
    }
}
