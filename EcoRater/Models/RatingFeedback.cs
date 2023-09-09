using System;
namespace EcoRater.Models
{
    public class RatingFeedback
    {
        public int Id { get; set; } // Primary Key
        public string AnswersToQuestions { get; set; } // This can be a JSON or a serialized string
        public double EnvironmentalRating { get; set; }
        public double SocialRating { get; set; }
        public double EconomicRating { get; set; }
        public string AIRecommendations { get; set; }
        public DateTime Timestamp { get; set; }
        public int ProjectFirmId { get; set; } // Foreign Key to ProjectFirm

        // Navigation Property
        public ProjectFirm ProjectFirm { get; set; }
    }

}

