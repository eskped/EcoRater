using System;
namespace EcoRater.Models
{
	public class Rating
	{
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? UserId { get; set; }
        public string? UserAnswers { get; set; }

        public string? OverallRating { get; set; }
        public double? EnvironmentalRating { get; set; }
        public double? SocialRating { get; set; }
        public double? EconomicRating { get; set; }
        public string? FutureRecommendations { get; set; }

        public int? ProjectFirmId { get; set; } // Foreign Key to ProjectFirm

        // Navigation Property
        public ProjectFirm? ProjectFirm { get; set; }
    }
}

