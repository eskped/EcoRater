using System;
namespace EcoRater.Models
{
	public class SustainabilityAssessment
	{
        
        public string? Industry { get; set; }
        public string? BusinessNature { get; set; }
        public string? BusinessSize { get; set; }
        public string? OperationalRegions { get; set; }
        public bool? ManufacturingInvolved { get; set; }
        public bool? SourcingFromOutside { get; set; }
        public string? SourcingType { get; set; } // Local or International
        public bool? ImpactOnLandUse { get; set; }
        public int? NumberOfEmployees { get; set; }
        public bool? InteractWithLocalCommunities { get; set; }
        public bool? PreviousSustainabilityInitiatives { get; set; }
        public string? ExistingSustainabilityGoals { get; set; }
        public bool? UseOfNaturalResources { get; set; }
        public bool? ProduceEmissionsOrWaste { get; set; }
    }
}

