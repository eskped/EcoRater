using System;
using Microsoft.AspNetCore.Identity;

namespace EcoRater.Models
{
    public class ProjectFirm
    {
        public int Id { get; set; } // Primary Key
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Region { get; set; }
        public string? UserId { get; set; } // Foreign Key to User

        public string? Industry { get; set; }
        public string? BusinessNature { get; set; }
        public string? BusinessSize { get; set; }
        public string? OperationalRegions { get; set; }
        public bool? ManufacturingInvolved { get; set; }
        public bool? SourcingFromOutside { get; set; }
        public string? SourcingType { get; set; } // Local or International
        public bool? ImpactOnLandUse { get; set; }
        public int? NumberOfEmployees { get; set; }
        public bool? PreviousSustainabilityInitiatives { get; set; }
        public bool? ProduceEmissionsOrWaste { get; set; }

        public string? QuestionsText { get; set; }
        public string? UserAnswers { get; set; }

        public string? OverallRating { get; set; }
        public double? EnvironmentalRating { get; set; }
        public double? SocialRating { get; set; }
        public double? EconomicRating { get; set; }
        public string? FutureRecommendations { get; set; }

        // Navigation Property
        public IdentityUser? User { get; set; }
    }
}
